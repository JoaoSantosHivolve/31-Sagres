using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCurrentTime : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "New Order " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
    }
}
