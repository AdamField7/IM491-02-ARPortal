using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextReciever : MonoBehaviour
{
    public TMP_Text debugText;
    public static TextReciever TR;
    public string WhatIWantToWrite;
    public Transform[] WhatWeWantToTrack;

    // Start is called before the first frame update
    void Start()
    {
        TR = this;
    }

    public void Update()
    {
        debugText.text = "";
        foreach(var item in WhatWeWantToTrack)
        {
            debugText.text = debugText.text + item.name + ": " + item.position;
        }

    }
}
