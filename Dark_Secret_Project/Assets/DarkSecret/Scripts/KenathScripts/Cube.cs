using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Cube : MonoBehaviour
    {
    public enum CubeColor
    {
        Blue, Red, Green
    }
        [SerializeField]
        private CubeColor cubeId;

        public CubeColor CubeId => this.cubeId;

    }

