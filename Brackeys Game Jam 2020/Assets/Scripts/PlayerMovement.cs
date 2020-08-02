using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private float input;
    [Header("Movement")]
    [SerializeField]
    private float speed = 7;

    [SerializeField]
    private float jumpPower = 5;

    [Header("Jump Checker")]
    [SerializeField]
    private bool canJump = false;

    Vector2 moveAmount;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = Input.GetAxisRaw("Horizontal");

        moveAmount = new Vector2(input * speed * Time.fixedDeltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rigidbody2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(moveAmount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Jumpable")
        {
            canJump = true;
        }
    }
}
