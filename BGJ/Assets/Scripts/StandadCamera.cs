using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandadCamera : MonoBehaviour
{
    [Range(0.01f, 15f)]
    public float desiredAspect;

    [Range(0.01f, 15f)]
    public float desiredSize;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //sets height
        camera.orthographicSize = desiredSize;

        //sets the ratio between height and width
        camera.aspect = desiredAspect;
    }
}
