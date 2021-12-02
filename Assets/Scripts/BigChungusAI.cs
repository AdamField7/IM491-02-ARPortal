using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigChungusAI : MonoBehaviour
{
    public Camera ARCamera;
    public GameObject chungus;

    public GameObject right1;
    public GameObject right2;
    public GameObject middle1;
    public GameObject middle2;
    public GameObject left1;
    public GameObject left2;

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
                            chungus.transform.position = left1.transform.position;
                            StartCoroutine(MoveOverSeconds(chungus, left2.transform.position, 5f));
                        }
                        else if (hitObject.transform.tag == "RightRock")
                        {
                            chungus.transform.position = right1.transform.position;
                            StartCoroutine(MoveOverSeconds(chungus, right2.transform.position, 5f));
                        }
                        else if (hitObject.transform.tag == "MiddleRock")
                        {
                            chungus.transform.position = middle1.transform.position;
                            StartCoroutine(MoveOverSeconds(chungus, middle2.transform.position, 5f));
                        }
                    }
                }
            }
        }
    }
}

