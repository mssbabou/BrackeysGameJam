using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReplayScript : MonoBehaviour
{
    public bool isPlaying = false;
    public bool isRecording = false;
    private bool recordingCleared = false;
    private bool setPositionToRecordingLengthDone = false;

    private int position = 0;

    public List<Vector2> positions;

    Rigidbody2D rb;

    private GameObject ghostPlayer;

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector2>();
        rb = GetComponent<Rigidbody2D>();

        ghostPlayer = GameObject.Find("Ghost");
    }

    // Update is called once per frame
    void Update()
    {
        ghostPlayer.SetActive(isPlaying);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isRecording)
            {
                isRecording = false;
            }
            if (isPlaying == false)
            {
                isPlaying = true;
                print("setting play to true");
            }
            else
            {
                isPlaying = false;
                print("setting play to false");
            }
            
        }
        
       
            

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(isPlaying)
            {
                isPlaying = false;
            }

            if (isRecording == false)
            {
                isRecording = true;
                print("setting record to true");
            }
            else
            {
                isRecording = false;
                print("setting record to false");
            }
        }
            

        Image recording = GameObject.Find("Recording/ForeGround").GetComponent<Image>();
        Image playing = GameObject.Find("Playing/ForeGround").GetComponent<Image>();

        recording.enabled = isRecording;
        playing.enabled = isPlaying;
    }

    void FixedUpdate()
    {
        if (isPlaying && !isRecording)
        {
            if (!setPositionToRecordingLengthDone)
            {
                position = positions.Count - 1;
                print("position set");
            }
            Play();
            
            //print("called play method");
        }
        
        if (!isPlaying && isRecording)
        {
            Record();
            //print("called record method");
        }

        if (!isRecording)
        {
            if(positions.Count > 0)
            {
                recordingCleared = false;
            }
           
        }

    }

    void Play()
    {
        setPositionToRecordingLengthDone = true;

        if (position == 0)
        {
            StopPlay();
            print(position);
            print("Countdown complete");
        }
        else
        {
            ghostPlayer.transform.position = positions[position];
            position = position -1;
        }
    }

        

    

    void Record()
    {
        ClearOldRecording();
        positions.Insert(0, transform.position);
    }

    void ClearOldRecording()
    {
        if (!recordingCleared)
        {
            recordingCleared = true;
            positions = new List<Vector2>();
        }
    }

    public void StartPlay()
    {
        print("Called Stop Play Method");
        isPlaying = true;
        rb.isKinematic = true;
    }

    public void StopPlay()
    {
        print("Called Stop Play Method");
        setPositionToRecordingLengthDone = false;
        isPlaying = false;
        rb.isKinematic = false;
    }
}
