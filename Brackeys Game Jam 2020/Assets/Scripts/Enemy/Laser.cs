using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 displacment;
    private Vector2 velocity;
    private Vector2 moveAmount;
    [SerializeField]
    private float speed;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
            
        displacment = playerTransform.position - transform.position;
        direction = displacment.normalized;
        velocity = direction * speed;
        moveAmount = velocity * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        transform.Translate(moveAmount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag != ("Laser"))
        {
            Destroy(gameObject);
        }
        
    }
}
