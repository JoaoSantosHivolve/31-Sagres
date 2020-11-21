using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TheoryVideoController : MonoBehaviour
{
    public int debugStep;
    private int m_CurrentStep;
    public int CurrentStep
    {
        get => m_CurrentStep;
        set
        {
            if (value >= timeStamps.Count)
            {
                m_CurrentStep = timeStamps.Count;
                right.interactable = false;
            }
            else if (value <= 0)
            {
                m_CurrentStep = 0;
                left.interactable = false;
            }
            else
            {
                m_CurrentStep = value;
            }
            debugStep = m_CurrentStep;
        }
    }

    public VideoPlayer videoPlayer;
    public List<float> timeStamps;

    [Header("Buttons")]
    public GameObject startQuestionsButton;
    public Button left;
    public Button right;

    private void Awake()
    {
        CurrentStep = 0;
        left.onClick.AddListener(AdvanceLeft);
        right.onClick.AddListener(AdvanceRight);
        videoPlayer.Pause();
    }

    private void AdvanceLeft()  => Advance(-1);
    private void AdvanceRight() => Advance(1);

    private void Advance(int increment)
    {
        StartCoroutine(PlayVideo(increment >= 0 ? VideoDirection.Forward : VideoDirection.Backwards));
    }

    private IEnumerator PlayVideo(VideoDirection direction)
    {
        left.interactable = false;
        right.interactable = false;

        float duration = 0;

        if(direction == VideoDirection.Forward)
        {
            videoPlayer.Play();
            duration = timeStamps[CurrentStep];
        }
        else
        {
            float videoTime = 0;

            for (int i = 0; i < CurrentStep -1; i++)
            {
                videoTime += timeStamps[i];
            }

            videoPlayer.time = videoTime;
        }

        yield return new WaitForSeconds(duration);

        videoPlayer.Pause();
        CurrentStep += direction == VideoDirection.Forward ? 1:-1;
        left.interactable = CurrentStep == 0 ? false : true;
        right.interactable = CurrentStep == timeStamps.Count ? false : true;

        startQuestionsButton.SetActive(CurrentStep == timeStamps.Count);
    }
}