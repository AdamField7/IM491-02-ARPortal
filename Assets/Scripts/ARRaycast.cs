using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARRaycast : MonoBehaviour
{
    public Camera ARCamera;
    public GameObject objectRef;
    public List<GameObject> Planes;
    public ARPlaneManager ARPM;
    public static ARRaycast ARRC;


    public void Start()
    {
        ARRC = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    objectRef.transform.position = hitObject.point;
                }
            }
        }
    }
}
