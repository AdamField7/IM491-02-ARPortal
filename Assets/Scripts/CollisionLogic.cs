using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogic : MonoBehaviour
{

    public GameObject[] objectsInScene;
    public TextReciever TR;
    public GameObject door;
    public GameObject lookingIN;
    public GameObject lookingOUT;
    public GameObject back;
    public GameObject DefaultLayerChildren;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Door")
        {
            TextReciever.TR.debugText.text = "HIT";

            door = other.gameObject;
            foreach(Transform obj in DefaultLayerChildren.transform)
            {
                if(gameObject.transform.position.z < door.transform.position.z)
                {
                    obj.gameObject.layer = 0;
                    lookingIN.gameObject.SetActive(false);
                    lookingOUT.gameObject.SetActive(true);
                    back.layer = 8;
                }
                else
                {
                    obj.gameObject.layer = 7;
                    lookingIN.gameObject.SetActive(true);
                    lookingOUT.gameObject.SetActive(true);
                    back.layer = 7;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
