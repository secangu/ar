using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class Interfaces : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] int points;

    public void TargetFound(GameObject Canvas)
    {
        if (Canvas != null)
            Canvas.SetActive(true);    
        Time.timeScale = 1;
    }
    
    public void TargetLost(GameObject Canvas)
    {
        if (Canvas != null)
            Canvas.SetActive(false);
        Time.timeScale = 0;
    }
    public void PlayVideo(VideoPlayer video)
    {
        if (video != null)
        {
            video.Play();
        }
    }    
    public void IncreasePoints()
    {
        points += 10;
        textMeshProUGUI.text = "Points: " + points;
    }
    public void DecreasePoints()
    {
        if (points >= 5) 
            points -= 5;

        textMeshProUGUI.text = "Points: " + points;
    }
}
