using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Camera camera;
    private Vector2 mousePosition;
    [SerializeField]
    private float projectileForce;
    [SerializeField]
    private GameObject projectile;
    private Vector2 unitCircleOffset;
    [SerializeField]
    private float offsetScale = 1.5f;
    private Vector2 direction;
    private Vector2 displacment;
    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            displacment = mousePosition - (Vector2)transform.position;
            direction = displacment.normalized;
            unitCircleOffset = direction * offsetScale;
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        GameObject currentProjectile = Instantiate(projectile, (Vector2)transform.position + unitCircleOffset, Quaternion.identity);
        currentProjectile.GetComponent<Rigidbody2D>().AddForce(direction * projectileForce, ForceMode2D.Impulse);
    }
}
