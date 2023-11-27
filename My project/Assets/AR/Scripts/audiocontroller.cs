using System.Collections.Generic;
using UnityEngine;

public class audiocontroller : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjects;
    [SerializeField] List<AudioClip> audioClips;
    [SerializeField] int activeObjectIndex;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        activeObjectIndex = 0;

        for (int i = 0; i < gameObjects.Count; i++)
        {
            gameObjects[i].SetActive(false);
        }

        if (gameObjects.Count > 0 && audioClips.Count == gameObjects.Count)
        {
            gameObjects[activeObjectIndex].SetActive(true);
            audioSource.clip = audioClips[activeObjectIndex];
        }
    }

    void Update()
    {

    }
    public void Increment()
    {
        audioSource.Stop();
        gameObjects[activeObjectIndex].SetActive(false);
        activeObjectIndex = (activeObjectIndex + 1) % gameObjects.Count;

        gameObjects[activeObjectIndex].SetActive(true);
        audioSource.clip = audioClips[activeObjectIndex];

    }

    public void Decrement()
    {


        audioSource.Stop();
        gameObjects[activeObjectIndex].SetActive(false);
        activeObjectIndex = (activeObjectIndex - 1) % gameObjects.Count;

        if (activeObjectIndex < 0)
        {
            activeObjectIndex = gameObjects.Count-1;
        }

        gameObjects[activeObjectIndex].SetActive(true);
        audioSource.clip = audioClips[activeObjectIndex];


    }
    public void PlaySound()
    {
        audioSource.Play();
    }
}
