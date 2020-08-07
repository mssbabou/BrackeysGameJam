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
        Destroy(gameObject, 2);
    }

    void Update(){
        displacment = transform.position - target.transform.position;
        direction = displacment.normalized;
        moveAmount = direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col){
        Destroy(gameObject);
    }
}
