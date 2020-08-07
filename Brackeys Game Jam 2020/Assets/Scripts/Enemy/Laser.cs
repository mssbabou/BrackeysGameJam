using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 displacment;
    private Vector2 moveAmount;
    public float speed;

    private Transform target;
    Vector3 pos;

    void Start(){
        target = GameObject.Find("Player").transform;
        pos = target.position;
    }

    void Update(){
        displacment = transform.position - pos;
        direction = displacment.normalized;
        moveAmount = direction * speed * Time.deltaTime;

        transform.Translate(-moveAmount * speed * Time.deltaTime);

        if(transform.position.x == pos.x && transform.position.y == pos.y){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        Destroy(gameObject);
    }
}
