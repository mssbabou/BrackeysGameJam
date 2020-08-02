using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerReplayScript : MonoBehaviour
{
    public bool isRewinding = false;

    public List<Vector2> positions; 

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            StartRewind();
        else if (Input.GetKeyDown(KeyCode.LeftControl))
            StopRewind();

    }

    void FixedUpdate()
    {
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        } 
    }

    void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[positions.Count - 1];
            positions.RemoveAt(positions.Count - 1);
        }
        else
        {
            StopRewind();
        }

    }

    void Record()
    {
        positions.Insert(0, transform.position);
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }
}
