using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

class EnemyMovement : MonoBehaviour
{
    private bool onPlatformEdge = false;
    private bool goingLeft = true;
    private Vector2 input;

    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Update()
    {

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
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        if (goingLeft)
        {
            goingLeft = false;
        }
        else
        {
            goingLeft = true;
        }
    }

    private void MoveEnemy()
    {
        input = Vector2.right * speed;

        transform.Translate(input * Time.fixedDeltaTime);
    }
}
