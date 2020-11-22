using Common;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct Script
{
    public Character character;
    public string text;
}

public class ScriptController : MonoBehaviour
{
    public List<Script> script;
    public int index;

    public GameObject manBalloonPosition;
    public GameObject womanBalloonPosition;
    public GameObject ballon;
    public TextMeshProUGUI balloonText;
    public Button advanceButton;
    private Vector3 m_TargetPos;

    private void Awake()
    {
        balloonText.text = script[index].text;
        var width = ballon.GetComponent<RectTransform>().rect.width;
        var height = ballon.GetComponent<RectTransform>().rect.height;
        ballon.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        ballon.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        ballon.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }

    private void Update()
    {
        m_TargetPos = script[index].character == Character.Man ? manBalloonPosition.transform.position : womanBalloonPosition.transform.position;
        ballon.transform.position = Camera.main.WorldToScreenPoint(m_TargetPos);
    }

    public void NextStep_Button()
    {
        index++;
     
        balloonText.text = script[index].text;

        if (index == script.Count-1)
            advanceButton.interactable = false;
    }
}
