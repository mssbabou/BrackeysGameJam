using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    private Vector2 displacment;

    [SerializeField]
    [Range(0,1)]
    private float moveAmountPerFrame;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        displacment = playerTransform.position - transform.position;
        transform.Translate(displacment * moveAmountPerFrame);
    }
}
