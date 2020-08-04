using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField]
    private float lifeLength;
    [SerializeField]
    private float deathDelayLength;

    private bool isBoulder = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBoulder)
        {
            if(collision.collider.tag == "KillBox")
            {
                StartCoroutine(DestroyGameObject(0));
            }
        }
        else
        {
            StartCoroutine(DestroyGameObject(deathDelayLength));
        }
        
    }

    private void Start()
    {
        StartCoroutine(DestroyGameObject(lifeLength));
        if(gameObject.tag == "Boulder")
        {
            isBoulder = true;
        }
    }

    IEnumerator DestroyGameObject(float x)
    {
        yield return new WaitForSeconds(x);
        Destroy(gameObject);

    }
}
