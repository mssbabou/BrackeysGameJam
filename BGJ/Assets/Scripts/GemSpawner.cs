using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    float HalfScreenWidthInWorldUnits;
    float HalfScreenHeightInWorldUnits;
    float cameraAspectRatio;
    [SerializeField]
    [Range(0f, 10f)]
    float spawnHeight;
    [SerializeField]
    [Range(0f, 5f)]
    float spawnWaitTime;

    public GameObject prefab;

    Vector3 randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        cameraAspectRatio = Camera.main.aspect;
        HalfScreenWidthInWorldUnits = Camera.main.orthographicSize;
        HalfScreenHeightInWorldUnits = HalfScreenWidthInWorldUnits * cameraAspectRatio;
        Invoke("InstantiateInRandomPosition", spawnWaitTime);
    }

    // Update is called once per frame
    

    void InstantiateInRandomPosition()
    {
        randomPosition = new Vector3(Random.Range(-HalfScreenWidthInWorldUnits, HalfScreenWidthInWorldUnits), spawnHeight, 0);
        Instantiate(prefab, randomPosition, Quaternion.identity);
        Invoke("InstantiateInRandomPosition", spawnWaitTime);
    }
}
