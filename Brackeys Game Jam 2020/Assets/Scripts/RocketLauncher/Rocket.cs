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

    public GameObject explosionPrefab;

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

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Projectile"){
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }else{
            _Explode();
        }
    }

    public void _Explode(){
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 1);
        Destroy(gameObject);
    }
}
