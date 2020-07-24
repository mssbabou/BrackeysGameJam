using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows everyone to have the same camera size, or be able to change it, values can be made fixed once decision has been made

public class StandadCamera : MonoBehaviour
{
    [Header("Aspect Ratio & Size")]
    [Range(0.01f, 15f)]
    public float desiredAspect = 1.4f;

    [Range(0.01f, 15f)]
    public float desiredSize = 4.85f;
    Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();

        FixNullErrors();

        AdjustCamera();
    }

    void FixNullErrors()
    {
        //stops aspect from throwing an error
        if (desiredAspect <= 0)
        {
            desiredAspect = 0.1f;
        }

        //stops size from throwing an error
        if (desiredSize <= 0)
        {
            desiredSize = 0.1f;
        }
    }

    void AdjustCamera()
    {
        //sets height
        camera.orthographicSize = desiredSize;

        //sets the ratio between height and width
        camera.aspect = desiredAspect;
    }
}
