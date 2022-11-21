using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseLights : MonoBehaviour
{
    [SerializeField]
    Material litMaterial;
    [SerializeField]
    Material unlitMaterial;

    MeshRenderer renderer;

    private void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material = unlitMaterial;
    }

    public void LightUp()
    {
        renderer.material = litMaterial;
    }

    public void NoLight()
    {
        renderer.material = unlitMaterial;
    }
}
