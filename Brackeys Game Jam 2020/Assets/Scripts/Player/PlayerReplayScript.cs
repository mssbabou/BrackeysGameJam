﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReplayScript : MonoBehaviour
{
    public float recordingTime;
    private float time;
    private float playTime;
    private float playTimer;

    private bool canRecord;
    private bool canPlay;

    public bool isPlaying = false;
    public bool isRecording = false;
    private bool recordingCleared = false;
    private bool setPositionToRecordingLengthDone = false;

    private int position = 0;

    public List<Vector2> positions;

    Rigidbody2D rb;

    public GameObject ghostPlayerPrefab;
    private GameObject ghostPlayer;

    void Start()
    {
        positions = new List<Vector2>();
        rb = GetComponent<Rigidbody2D>();

        ghostPlayer = Instantiate(ghostPlayerPrefab);

        if(recordingTime == 0){
            recordingTime = 5;
        }
        time = recordingTime;
    }

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
                if(!canPlay) return;
                isPlaying = true;
            }
            else
            {
                isPlaying = false;
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
                if(!canRecord) return;
                isRecording = true;
            }
            else
            {
                isRecording = false;
            }
        }
            
        if(time <= 0)
        {
            isRecording = false;
        }
        if(isRecording)
        {
            playTimer += Time.deltaTime;
            playTime = playTimer;
        }
        else if(isPlaying)
        {
            playTime -= Time.deltaTime;
        }

        Image recording = GameObject.Find("Recording/ForeGround").GetComponent<Image>();
        Image playing = GameObject.Find("Playing/ForeGround").GetComponent<Image>();

        recording.fillAmount = time / recordingTime;
        playing.fillAmount = playTime / playTimer;

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
            time = recordingTime;
        }
        else
        {
            time -= Time.deltaTime;
        }

    }

    void Play()
    {
        setPositionToRecordingLengthDone = true;

        if (position == 0)
        {
            StopPlay();
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
        isPlaying = true;
        rb.isKinematic = true;
    }

    public void StopPlay()
    {
        setPositionToRecordingLengthDone = false;
        isPlaying = false;
        rb.isKinematic = false;
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "RecordingPlatform")
        {
            canRecord = true;
            canPlay = true;
        }  
    }
    void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "RecordingPlatform")
        {
            canRecord = true;
            canPlay = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "RecordingPlatform")
        {
            canRecord = false;
            canPlay = false;
        }
    }
}
