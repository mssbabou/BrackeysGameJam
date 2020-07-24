using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    float width = Camera.main.orthographicSize * Camera.main.aspect;

    Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.x = transform.x + Random.Range(-width, width);
        print(transform.x);
    }
}
