using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;

    private Transform target;
    Vector2 pos;

    void Start(){
        target = GameObject.Find("Player").transform;
        pos = target.position;
    }

    void Update(){
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), pos, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col){
        Destroy(gameObject);
    }
}
