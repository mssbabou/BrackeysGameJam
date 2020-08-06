using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float maxHealth = 5;
    private float health;

    public Image healthBar_fill;

    private Animator anim;

    private GameObject player;

    void Start(){
        anim = GetComponent<Animator>();
        health = maxHealth;
        healthBar_fill.fillAmount = health / maxHealth;
        player = GameObject.Find("Player");
    }

    void Update(){
        
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
