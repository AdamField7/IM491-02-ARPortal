using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigChungusAI : MonoBehaviour
{
    public Camera ARCamera;
    public GameObject chungus;

    private Vector3 behindRockLeft = new Vector3(-6.89f, 1.54f, 18f);
    private Vector3 behindRockRight = new Vector3(5.44f, 1.54f, 11.03f);
    private Vector3 behindRockMiddle = new Vector3(0, 3.53f, 16.2f);

    private Vector3 frontLeftRock = new Vector3(0, 1.54f, 18);
    private Vector3 frontRightRock = new Vector3(5.44f, 1.54f, 24.44f);
    private Vector3 frontMiddleRock = new Vector3(0, 5.55f, 14.33f);

    private bool bigChungusIsNotMoving = true;

  public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }


    // Update is called once per frame
    void Update()
    {
        if(bigChungusIsNotMoving)
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
                        if (hitObject.transform.tag == "LeftRock")
                        {
                            chungus.transform.position = behindRockLeft;
                            StartCoroutine(MoveOverSeconds(chungus, frontLeftRock, 5f));
                        }
                        else if (hitObject.transform.tag == "RightRock")
                        {
                            chungus.transform.position = behindRockRight;
                            StartCoroutine(MoveOverSeconds(chungus, frontRightRock, 5f));
                        }
                        else if (hitObject.transform.tag == "MiddleRock")
                        {
                            chungus.transform.position = behindRockMiddle;
                            StartCoroutine(MoveOverSeconds(chungus, frontMiddleRock, 5f));
                        }
                    }
                }
            }
        }
    }
}

