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

    public GameObject uiBorder;
    public GameObject uiStep1;
    public Animator uiAnimator;

    public Animator manAnimator;
    public Animator womanAnimator;
    bool isDone;
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
        if (isDone)
            return;

        m_TargetPos = script[index].character == Character.Man ? manBalloonPosition.transform.position : womanBalloonPosition.transform.position;
        ballon.transform.position = Camera.main.WorldToScreenPoint(m_TargetPos);

        manAnimator.SetBool("man_talking", script[index].character == Character.Man);
        womanAnimator.SetBool("woman_talking", script[index].character == Character.Woman);
    }

    public void NextStep_Button()
    {
        index++;

        if (index >= script.Count)
        {
            uiAnimator.SetTrigger("step3_open");
            manAnimator.SetBool("man_talking",false);
            uiAnimator.SetTrigger("step2_close");
            index = script.Count - 1; // Update later bug.
            isDone = true;
            return;
        }

        if (index == 5)
        {
            uiBorder.SetActive(true);
            uiStep1.SetActive(true);
            ballon.SetActive(false);
            return;
        }
        if(index == 6)
        {
            uiBorder.SetActive(false);
            ballon.SetActive(true);
        }
     
        balloonText.text = script[index].text;

        
    }
}
