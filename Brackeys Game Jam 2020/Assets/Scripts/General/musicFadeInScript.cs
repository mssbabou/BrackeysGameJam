using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicFadeInScript : MonoBehaviour
{
    [SerializeField]
    private GameObject musicToBeFaded;
    private AudioSource audio;
    [SerializeField]
    private float volumeIncrement;
    // Start is called before the first frame update
    void Start()
    {
        audio = musicToBeFaded.GetComponent<AudioSource>();
        audio.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = audio.volume + volumeIncrement;
    }
}
