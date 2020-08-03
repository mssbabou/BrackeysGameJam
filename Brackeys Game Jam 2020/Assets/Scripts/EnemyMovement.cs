using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform groundCheck;
    public Transform wallCheck;
    private float radius = 0.3f;
    public LayerMask wall;
 
    private bool facingRight;
    private bool touchingWall;

    private GameObject canvas;

    void Start(){
        string canvasFind = gameObject.name + "/Canvas";
        canvas = GameObject.Find(canvasFind);
    }

    void Update(){
        //move
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        //groundDetection
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, 2);
        if(!groundInfo.collider){
            Flip();
        }

        //wallDetection
        touchingWall = Physics2D.OverlapCircle(wallCheck.position, radius, wall);
        if(touchingWall){
            Flip();
        }
    }

    int i = 0;
    void Flip(){
        if(facingRight){
            transform.eulerAngles = new Vector3(0, -180, 0);
        }else{
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        facingRight = !facingRight;
        if(i == 1){
            Vector3 canvasScaler = canvas.transform.localScale;
            canvasScaler.x *= -1;
            canvas.transform.localScale = canvasScaler;    
        }
        i = 1;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;   
        Gizmos.DrawWireSphere(wallCheck.position, radius);
    }
}
