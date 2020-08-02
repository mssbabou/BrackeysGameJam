using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerReplayScript : MonoBehaviour
{
    public bool isPlaying = false;
    public bool isRecording = false;

    public List<Vector2> positions;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector2>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
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
        
       
            

        if (Input.GetKeyDown(KeyCode.R) && isRecording == false)
        {
            isRecording = true;
        }           
        else
        {
            isRecording = false;
        }
            


    }

    void FixedUpdate()
    {
        if (isPlaying && !isRecording)
        {
            Play();
        }
        
        if (!isPlaying && isRecording)
        {
            Record();
        }

    }

    void Play()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[positions.Count - 1];
            positions.RemoveAt(positions.Count - 1);
        }
        else
        {
            StopPlay();
        }

    }

    void Record()
    {
        positions.Insert(0, transform.position);
    }

    public void StartPlay()
    {
        isPlaying = true;
        rb.isKinematic = true;
    }

    public void StopPlay()
    {
        isPlaying = false;
        rb.isKinematic = false;
    }
}
