using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;

    private Transform target;
    Vector3 pos;

    void Start(){
        target = GameObject.Find("Player").transform;
        pos = target.position;
        Destroy(gameObject, 2);
    }

    void Update(){
        float distance = Vector3.Distance(transform.localPosition, pos);
        Vector3 heading = pos - transform.localPosition;
        Vector3 direction = heading / distance;
             
        float deltaSpeed = speed * Time.deltaTime;
        transform.Translate(direction.x * deltaSpeed, direction.y * deltaSpeed, direction.z * deltaSpeed);
    }

    void OnCollisionEnter2D(Collision2D col){
        Destroy(gameObject);
    }
}
