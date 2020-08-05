using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public bool facingRight = true;

    private Vector2 lastPosition;
    private Vector2 newPosition;

    void Update(){
        newPosition = transform.position;

        if(lastPosition.x < newPosition.x){
            facingRight = true;
        }else if(lastPosition.x > newPosition.x){
            facingRight = false;
        }

        lastPosition = transform.position;

        if(facingRight){
            GetComponent<SpriteRenderer>().flipX = false;
        }else{
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
