using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

class EnemyMovement : MonoBehaviour
{
    private GameObject enemyHolder;

    private bool onPlatformEdge = false;

    [SerializeField]
    private bool goingLeft = false;

    private Vector2 input;

    [SerializeField]
    private float speed;
    // Start is called before the first frame update

    private void Start()
    {
        enemyHolder = GameObject.Find("Enemy Container");
        transform.parent = enemyHolder.transform;
    }

    void Update()
    {
         //Returns True if enemy is at the edge of a platform, used to change direction.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveEnemy();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Platform")
        {
            print("I collided with an object of tag " + collision.collider.tag);
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        if (goingLeft)
        {
            goingLeft = false;
            speed = speed * -1;
        }
        else
        {
            goingLeft = true;
            speed = speed * -1;
        }
    }

    private void MoveEnemy()
    {
        input = Vector2.right * speed;

        transform.Translate(input * Time.fixedDeltaTime);
    }
}
