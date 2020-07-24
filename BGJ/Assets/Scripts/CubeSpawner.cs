using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    // Finsing half of the width of the camera viewport
    float width = Camera.main.orthographicSize * Camera.main.aspect;

    Transform transform;

    Vector3 offset;

    // Serializing the prefab we want to instantiate at run time
    public GameObject prefab;

    // Serializing the height of the CubeSpawner object in game
    [Range(-15f, 15f)]
    public float spawnHeight = 6f;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Finding the random place to send the CubeSpawner to Instantiate a Minecraft Cube!!!
        offset = new Vector3(Random.Range(-width, width), spawnHeight, 0);

        // Debug code
        print(offset);

        // Instantiating the Minecraft cube at the right
        Instantiate(prefab, offset, Quaternion.identity);
    }
}
