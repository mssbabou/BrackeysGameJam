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
    
    private float timeToDisplay;

    [HideInInspector]
    public static float timeToCompleteLevel;

    public bool levelFinished;

    private bool stop = false;

    [Header("Rating")]
    public int levelIndex;
    public Text highscore;
    public static int stars;
    public float threeStars, twoStars;
    public Image rating;
    public Sprite[] ratings;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        currentPlayTime = 0;
        timeToDisplay = 0;
        if(levelFinished){
            rating.sprite = ratings[stars];
            string playerPrefs = "LevelStars" + levelIndex;
            if(stars > PlayerPrefs.GetInt(playerPrefs)){
                PlayerPrefs.SetInt(playerPrefs, stars);
            }
            stars = PlayerPrefs.GetInt(playerPrefs);
            highscore.text = "Best: " + stars + " stars";
        }
        if(finishDoor != null){
            finishDoor.GetComponent<FinishDoor>().PlayerFinishedLevel += StopTimeKeeper;
        }
    }
    void Update()
    {
        if (!stop)
        {
            currentPlayTime = Time.time;
            timeToDisplay  += Time.deltaTime;
        }
        if(timeDisp != null)
        {
            if(!levelFinished)
            {
                float time = Mathf.Round(timeToDisplay);
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
        if(timeToCompleteLevel <= threeStars){
            stars = 3;
        }else if(timeToCompleteLevel <= twoStars){
            stars = 2;
        }else{
            stars = 1;
        }
    }
}
