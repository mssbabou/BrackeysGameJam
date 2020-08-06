using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LevelTimeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject finishDoor;
    private float startTime;
    private float endTime;
    private float currentPlayTime;
    
    [HideInInspector]
    public float timeToCompleteLevel;

    private bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        finishDoor.GetComponent<FinishDoor>().PlayerFinishedLevel += StopTimeKeeper;
        startTime = Time.time;
    }
    void Update()
    {
        if (!stop)
        {
            currentPlayTime = Time.time;
        }
    }

    void StopTimeKeeper()
    {
        endTime = Time.time;
        stop = true;
        timeToCompleteLevel = endTime - startTime;
        print(timeToCompleteLevel);
    }

}
