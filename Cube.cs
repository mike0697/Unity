using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    public Material material;

    public void OnHitByRaycast()
    {
        gameObject.GetComponent<Renderer>().material = material;
    }
}
