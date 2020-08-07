using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;

    private Transform target;

    void Start(){
        target = GameObject.Find("Player").transform;
    }

    void Update(){
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target.position, speed * Time.deltaTime);
    }
}
