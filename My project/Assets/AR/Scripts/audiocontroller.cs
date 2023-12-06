using System.Collections.Generic;
using UnityEngine;

public class audiocontroller : MonoBehaviour
{

    [SerializeField] List<GameObject> gameObjects;
    [SerializeField] int activeObjectIndex;
    [SerializeField] bool estadoAudio;
    [SerializeField] AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        activeObjectIndex = 0;

        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].SetActive(false);
        }

        if (gameObjects.Count > 0)
        {
            gameObjects[activeObjectIndex].SetActive(true);

        }

    }

    void Update()
    {

    }
    public void Increment()
    {

        gameObjects[activeObjectIndex].SetActive(false);
        activeObjectIndex = (activeObjectIndex + 1) % gameObjects.Count;

        gameObjects[activeObjectIndex].SetActive(true);


    }

    public void Decrement()
    {



        gameObjects[activeObjectIndex].SetActive(false);
        activeObjectIndex = (activeObjectIndex - 1) % gameObjects.Count;

        if (activeObjectIndex < 0)
        {
            activeObjectIndex = gameObjects.Count - 1;
        }

        gameObjects[activeObjectIndex].SetActive(true);



    }


    public void StopSound()
    {
        estadoAudio = !estadoAudio;

        if (estadoAudio)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
    }
}