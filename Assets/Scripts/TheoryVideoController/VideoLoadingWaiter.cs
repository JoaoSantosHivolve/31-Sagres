using UnityEngine;
using UnityEngine.Video;

public class VideoLoadingWaiter : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Update()
    {
        if (videoPlayer.isPrepared)
            gameObject.SetActive(false);
    }
}