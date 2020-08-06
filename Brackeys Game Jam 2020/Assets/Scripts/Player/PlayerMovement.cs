using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Transform transform;
    Rigidbody2D rigidbody2D;
    float input;
    [Header("Movement")]
    [SerializeField]
    float speed = 7;

    bool facingRight = true;

    [SerializeField]
    float jumpPower = 5;

    [Header("Jump Checker")]
    [SerializeField]
    bool canJump = false;

    Vector2 moveAmount;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isMoving;
        input = Input.GetAxisRaw("Horizontal");
        if(input > 0 || input < 0){
            isMoving = true;
        }else{
            isMoving = false;
        }

        moveAmount = new Vector2(input * speed * Time.fixedDeltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rigidbody2D.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }

        if(facingRight){
            GetComponent<SpriteRenderer>().flipX = false;
        }else{
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if(input > 0){
            facingRight = true;
        }if(input < 0){
            facingRight = false;
        }

        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", canJump);
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
        if (collision.collider.tag == "Unjumpable")
        {
            canJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Jumpable")
        {
            canJump = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
