using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimeScript : MonoBehaviour
{
    public Text timeDisp;

    [SerializeField]
    private GameObject finishDoor;
    private float startTime;
    private float endTime;
    private float currentPlayTime;
    
    [HideInInspector]
    public static float timeToCompleteLevel;

    public bool levelFinished;

    public bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        if(finishDoor != null){
            finishDoor.GetComponent<FinishDoor>().PlayerFinishedLevel += StopTimeKeeper;
        }
        currentPlayTime = 0;
    }
    void Update()
    {
        if (!stop)
        {
            currentPlayTime = Time.time;
        }
        if(timeDisp != null)
        {
            if(!levelFinished)
            {
                float time = Mathf.Round(currentPlayTime);
                timeDisp.text = "Time: " + time + " s";
            }
            else
            {
                float time = Mathf.Round(timeToCompleteLevel);
                timeDisp.text = "Time: " + time + " s";
            }
        }
        
    }

    void StopTimeKeeper()
    {
        endTime = Time.time;
        stop = true;
        timeToCompleteLevel = endTime - startTime;
    }
}
