using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ARTests : MonoBehaviour
{
    private ARSessionOrigin ar;
    private ARCameraManager ARCM;

    // Start is called before the first frame update
    void Start()
    {
        ARCM.requestedFacingDirection = CameraFacingDirection.User;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
