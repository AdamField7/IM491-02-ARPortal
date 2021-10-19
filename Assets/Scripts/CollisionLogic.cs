using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogic : MonoBehaviour
{

    public GameObject ObjectHolder;
    public GameObject lookingIN;
    public GameObject lookingOUT;
    public List<Transform> objectsToIgnoreCollisionLogic;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Door")
        {
            Transform[] allChildren = ObjectHolder.GetComponentsInChildren<Transform>();
            var direction = other.transform.position - transform.position;

            foreach(var obj in allChildren)
            {
                if(!objectsToIgnoreCollisionLogic.Contains(obj))
                {
                    if (Vector3.Dot(other.transform.forward, direction) < 0)
                    {
                        var objectDirection = other.transform.position - obj.transform.position;
                        if(Vector3.Dot(other.transform.forward, objectDirection) > 0)
                        {
                            obj.gameObject.layer = 0;
                        }
                        else
                        {
                            obj.gameObject.layer = 8;
                        }
                        lookingIN.gameObject.SetActive(false);
                        lookingOUT.gameObject.SetActive(true);
                    }
                    else
                    {
                        obj.gameObject.layer = 7;
                        lookingIN.gameObject.SetActive(true);
                        lookingOUT.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
