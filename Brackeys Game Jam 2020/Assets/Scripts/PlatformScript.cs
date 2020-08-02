using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private GameObject platformHolder;
    // Start is called before the first frame update
    void Start()
    {
        platformHolder = GameObject.Find("Platform Container");
        transform.parent = platformHolder.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
