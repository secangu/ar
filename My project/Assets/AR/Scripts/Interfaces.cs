using UnityEngine;
using UnityEngine.Video;

public class ARController : MonoBehaviour
{
    public void PlayVideo(VideoPlayer video)
    {
        if (video != null)
        {
            video.Play();
        }
    }
    public void TargetFound(GameObject canvas)
    {
        if (canvas != null)
        {
            canvas.SetActive(true);
        }
    }

    public void TargetLost(GameObject canvas)
    {
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }

}
