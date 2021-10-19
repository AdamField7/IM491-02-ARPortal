using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigChungusAI : MonoBehaviour
{
    public Camera ARCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    if(hitObject.transform.tag == "LeftRock")
                    {

                    }
                    else if(hitObject.transform.tag == "RightRock")
                    {

                    }
                    else if(hitObject.transform.tag == "MiddleRock")
                    {

                    }
                }
            }
        }
    }
}
