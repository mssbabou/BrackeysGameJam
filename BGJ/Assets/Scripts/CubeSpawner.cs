using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    float width = Camera.main.orthographicSize * Camera.main.aspect;

    Transform transform;

    Vector3 offset;

    public GameObject prefab;

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
        

        offset = new Vector3(Random.Range(-width, width), spawnHeight, 0);

        print(offset);

        Instantiate(prefab, offset, Quaternion.identity);
    }
}
