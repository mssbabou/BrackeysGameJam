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

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        print("runningcoroutine");
        StartCoroutine(PlayerCheck());
    }

    IEnumerator PlayerCheck()
    {
        displacment = new Vector2(playerTransform.position.x, playerTransform.position.y + (playerTransform.localScale.y/2)) - (Vector2)transform.position;
        distance = displacment.magnitude;
        print(distance);
        if(distance < viewRange)
        {
            direction = displacment.normalized;
            print(direction);
            unitCircleOffset = direction * offsetScale;
            ShootAtPlayer();
            yield return new WaitForSeconds(2);
            print("Starting new coroutine");
            StartCoroutine(PlayerCheck());
        }
    }

    void ShootAtPlayer()
    {
        print("shot");
        velocity = direction * projectileForce;
        currentGameObject = Instantiate(projectile, (Vector2)transform.position + unitCircleOffset , Quaternion.identity);
        currentGameObject.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);
    }
}
