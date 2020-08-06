using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;

    bool flying;

    void Update(){
        if(flying){
            transform.Translate(new Vector2(0, 1) * speed);
        }
    }

    public void Fire(){
        flying = true;
    }
}
