using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlaneLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ARRaycast.ARRC.Planes.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
