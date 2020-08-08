using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Player player;
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
    bool isMoving;

    private Animator anim;

    [Header("Audio")]
    public AudioSource jump;
    public AudioSource walk;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>().playerDeath += stopInput();
        transform = GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine (WalkAudio());
    }

    private void stopInput();

    private void Update()
    {
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
            jump.Play();
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

    IEnumerator WalkAudio(){
        if(isMoving && canJump){
            walk.Play();
            yield return new WaitForSeconds(0.35f);
            if(isMoving && canJump){
                walk.Play();
                yield return new WaitForSeconds(0.45f);
                StartCoroutine (WalkAudio());
            }else{
                yield return new WaitForSeconds(0.05f);
                StartCoroutine (WalkAudio());
            }
        }else{
            yield return new WaitForSeconds(0.05f);
            StartCoroutine (WalkAudio());
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SlowDown") ;     
        {
            rigidbody2D.velocity = rigidbody2D.velocity / 10;
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
