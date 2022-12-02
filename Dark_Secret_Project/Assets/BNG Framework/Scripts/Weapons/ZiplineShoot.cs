using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BNG;

namespace BNG {

    /// <summary>
    /// An example weapon script that can fire Raycasts or Projectile objects
    /// </summary>
    public class ZiplineShoot : GrabbableEvents {

        public SceneInfo Sceneinfo;

        public JointHelper jntHlp;

        [Header("General : ")]
        /// <summary>
        /// How far we can shoot in meters
        /// </summary>
        public float MaxRange = 25f;

        /// <summary>
        /// How much damage to apply to "Damageable" on contact
        /// </summary>
        public float Damage = 25f;

        /// <summary>
        /// Semi requires user to press trigger repeatedly, Auto to hold down
        /// </summary>
        [Tooltip("Semi requires user to press trigger repeatedly, Auto to hold down")]
        public FiringType FiringMethod = FiringType.Semi;

        /// <summary>
        /// How does the user reload once the Clip is Empty
        /// </summary>
        public ReloadType ReloadMethod = ReloadType.InfiniteAmmo;

        /// <summary>
        /// Ex : 0.2 = 5 Shots per second
        /// </summary>
        [Tooltip("Ex : 0.2 = 5 Shots per second")]
        public float FiringRate = 2.4f;
        float lastShotTime;

        [Tooltip("Amount of force to apply to a Rigidbody once damaged")]
        public float BulletImpactForce = 1000f;

        /// <summary>
        /// Maximum amount of internal ammo this weapon can hold. Does not account for attached clips.  For example, a shotgun has internal ammo
        /// </summary>
        [Tooltip("Current Internal Ammo if you are keeping track of ammo yourself. Firing will deduct from this number. Reloading will cause this to equal MaxInternalAmmo.")]
        public float InternalAmmo = 0;

        /// <summary>
        /// Maximum amount of internal ammo this weapon can hold. Does not account for attached clips.  For example, a shotgun has internal ammo
        /// </summary>
        [Tooltip("Maximum amount of internal ammo this weapon can hold. Does not account for attached clips.  For example, a shotgun has internal ammo")]
        public float MaxInternalAmmo = 10;

        /// <summary>
        /// Set true to automatically chamber a new round on fire. False to require charging. Example : Bolt-Action Rifle does not auto chamber.  
        /// </summary>
        [Tooltip("Set true to automatically chamber a new round on fire. False to require charging. Example : Bolt-Action Rifle does not auto chamber. ")]
        public bool AutoChamberRounds = true;

        [Header("Projectile Settings : ")]

        [Tooltip("If true a projectile will always be used instead of a raycast")]
        public bool AlwaysFireProjectile = false;

        [Tooltip("How fast to fire the weapon during slowmo. Keep in mind this is affected by Time.timeScale")]
        public float SlowMoRateOfFire = 0.3f;

        [Tooltip("Amount of force to apply to Projectile")]
        public float ShotForce = 10f;

        [Tooltip("Amount of force to apply to the BulletCasingPrefab object")]
        public float BulletCasingForce = 3f;

        [Header("Recoil : ")]
        /// <summary>
        /// How much force to apply to the tip of the barrel
        /// </summary>
        [Tooltip("How much force to apply to the tip of the barrel")]
        public Vector3 RecoilForce = Vector3.zero;


        [Tooltip("Time in seconds to allow the gun to be springy")]
        public float RecoilDuration = 0.3f;

        Rigidbody weaponRigid;

        [Header("Raycast Options : ")]
        public LayerMask ValidLayers;

        [Header("Weapon Setup : ")]
        /// <summary>
        /// Transform of trigger to animate rotation of
        /// </summary>
        [Tooltip("Transform of trigger to animate rotation of")]
        public Transform TriggerTransform;

        [Header("Shown for Debug : ")]
        /// <summary>
        /// Is there currently a bullet chambered and ready to be fired
        /// </summary>
        [Tooltip("Is there currently a bullet chambered and ready to be fired")]
        public bool BulletInChamber = false;


        [Header("Events")]

        [Tooltip("Unity Event called when Shoot() method is successfully called")]
        public UnityEvent onShootEvent;

        /// <summary>
        /// Is the slide / receiver forced back due to last shot
        /// </summary>
        protected bool slideForcedBack = false;

        protected WeaponSlide ws;

        protected bool readyToShoot = true;

        void Start() {
            weaponRigid = GetComponent<Rigidbody>();
            Sceneinfo.previousScene = 1;
        }

        public override void OnTrigger(float triggerValue) {


            // Sanitize for angles 
            triggerValue = Mathf.Clamp01(triggerValue);

            // Update trigger graphics
            if (TriggerTransform) {
                TriggerTransform.localEulerAngles = new Vector3(triggerValue * 15, 0, 0);
            }

            // Trigger up, reset values
            if (triggerValue <= 0.5) {
                readyToShoot = true;
                playedEmptySound = false;
            }

            // Fire gun if possible
            if (readyToShoot && triggerValue >= 0.75f) {
                Shoot();

                // Immediately ready to keep firing if 
                readyToShoot = FiringMethod == FiringType.Automatic;
            }

            base.OnTrigger(triggerValue);
        }

        protected bool playedEmptySound = false;
        
        public virtual void Shoot() {

            // Has enough time passed between shots
            float shotInterval = Time.timeScale < 1 ? SlowMoRateOfFire : FiringRate;
            if (Time.time - lastShotTime < shotInterval) {
                return;
            }

            // Haptics
            if (thisGrabber != null) {
                input.VibrateController(0.1f, 0.2f, 0.1f, thisGrabber.HandSide);
            }  

            // We just fired this bullet, but now its a grapple lmao
            BulletInChamber = true;
            
            jntHlp.LockXRotation = true;

            // Try to load a new bullet into chamber         
            if (AutoChamberRounds) {
                chamberRound();
            }

            // Call Shoot Event
            if(onShootEvent != null) {
                onShootEvent.Invoke();
            }

            // Store our last shot time to be used for rate of fire
            lastShotTime = Time.time;
        }

        protected IEnumerator shotRoutine;

        public virtual int GetBulletCount() {
            if (ReloadMethod == ReloadType.InfiniteAmmo) {
                return 9999;
            }
            else if (ReloadMethod == ReloadType.InternalAmmo) {
                return (int)InternalAmmo;
            }
            else if (ReloadMethod == ReloadType.ManualClip) {
                return GetComponentsInChildren<Bullet>(false).Length;
            }

            // Default to bullet count
            return GetComponentsInChildren<Bullet>(false).Length;
        }

        public virtual void RemoveBullet() {

            // Don't remove bullet here
            if (ReloadMethod == ReloadType.InfiniteAmmo) {
                return;
            }

            else if (ReloadMethod == ReloadType.InternalAmmo) {
                InternalAmmo--;
            }
            else if (ReloadMethod == ReloadType.ManualClip) {
                Bullet firstB = GetComponentInChildren<Bullet>(false);
                // Deactivate gameobject as this bullet has been consumed
                if (firstB != null) {
                    Destroy(firstB.gameObject);
                }
            }
        }


        public virtual void Reload() {
            InternalAmmo = MaxInternalAmmo;
        }

        void chamberRound() {

            int currentBulletCount = GetBulletCount();

            if(currentBulletCount > 0) {
                // Remove the first bullet we find in the clip                
                RemoveBullet();

                // That bullet is now in chamber
                BulletInChamber = true;
            }
            // Unable to chamber a bullet
            else {
                BulletInChamber = false;
            }
        } 

        // Randomly scale / rotate to make them seem different
        public virtual void OnWeaponCharged(bool allowCasingEject) {

            chamberRound();

            // Slide is no longer forced back if weapon was just charged
            slideForcedBack = false;
        }
    }
}

