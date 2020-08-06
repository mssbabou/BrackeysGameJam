using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponScript : MonoBehaviour
{
    Transform playerTransform;
    Vector2 displacment;
    float distance;
    Vector2 direction;
    Vector2 velocity;
    [SerializeField]
    float projectileForce;
    [SerializeField]
    float viewRange;
    private Vector2 unitCircleOffset;
    [SerializeField]
    private float offsetScale = 1.5f;
    [SerializeField]
    GameObject projectile;
    GameObject currentGameObject;
    [SerializeField]
    float aimOffset;

    [Header("Audio")]
    public AudioSource shoot;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(PlayerCheck());
    }

    IEnumerator PlayerCheck()
    {
        yield return new WaitForSeconds(2);
        displacment = new Vector2(playerTransform.position.x, playerTransform.position.y + (playerTransform.localScale.y/2)) - (Vector2)transform.position;
        distance = displacment.magnitude;
        if(distance < viewRange)
        {
            direction = displacment.normalized;
            unitCircleOffset = direction * offsetScale;
            ShootAtPlayer();
            StartCoroutine(PlayerCheck());
        }
    }

    void ShootAtPlayer()
    {
        velocity = direction * projectileForce;
        currentGameObject = Instantiate(projectile, (Vector2)transform.position + unitCircleOffset , Quaternion.identity);
        currentGameObject.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);
        shoot.Play();
    }
}
