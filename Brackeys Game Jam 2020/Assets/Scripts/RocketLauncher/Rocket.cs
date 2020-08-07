using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Rocket : MonoBehaviour
{
    public delegate void RocketExplode();
    public RocketExplode Explode;

    [SerializeField]
    private Rigidbody2D rigidbody;
    public float speed;

    bool flying;

    void FixedUpdate(){
        if(flying)
        {

            transform.localPosition = (Vector2)transform.localPosition + (Vector2.up * speed * Time.fixedDeltaTime);
        }
    }

    public void Fire(){
        flying = true;
    }
}
