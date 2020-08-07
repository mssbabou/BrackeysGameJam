using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float maxHealth = 5;
    private float health;
    public Image healthBar_fill;

    private GameObject player;
    private Vector2 lastPos;
    Vector2 playerPos;

    private Animator anim;

    public LineRenderer leftEye;
    public LineRenderer rightEye;

    private bool lazerAttack = true;

    void Start(){
        anim = GetComponent<Animator>();
        health = maxHealth;
        healthBar_fill.fillAmount = health / maxHealth;
        player = GameObject.Find("Player");
        playerPos = new Vector2(player.transform.position.x + 1, player.transform.position.y);
    }

    void Update(){
        if(player.transform.position.x < transform.position.x){
            GetComponent<SpriteRenderer>().flipX = true;
        }else{
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if(lazerAttack){
            float timer = 0.5f;
            timer -= Time.deltaTime;
            if(timer <= 0){
                timer = 0.5f;
                lastPos = playerPos;
                playerPos = player.transform.position;
                rightEye.SetPosition(1, player.transform.position);
                //leftEye.SetPosition(1, lastPos);
            }
        }
    }

    void TakeDamage(float amount){
        health -= amount;
        healthBar_fill.fillAmount = health / maxHealth;

        anim.SetTrigger("Hurt");
        Invoke("Idle", 0.15f);
    }

    void Idle(){
        anim.SetTrigger("Idle");
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Rocket"){
            Destroy(col.gameObject);
            TakeDamage(1);
        }
    }
}
