using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth;
    private float health;

    public GameObject hitFeedback;

    public Image healthBar;
    public Text healthDisp;

    private bool isInvincible;
    private Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
        health = maxHealth;
        healthBar.fillAmount = health;
    }

    public void TakeDamage(float amount){
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
        healthDisp.text = health + "/" + maxHealth.ToString();

        GameObject h = Instantiate(hitFeedback, transform.position, Quaternion.identity);
        Destroy(h, 0.15f);

        if(health <= 0){
            Die();
        }
    }

    void Die(){
        print("You're Dead!!!");
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Enemy"){
            if(isInvincible) return;
            TakeDamage(10);
            StartCoroutine(GoInvincible(3));
            col.gameObject.GetComponent<EnemyMovement>().Flip();
        }
        if(col.gameObject.tag == "Projectile"){
            if(isInvincible) return;
            TakeDamage(10);
            StartCoroutine(GoInvincible(3));
        }
    }

    IEnumerator GoInvincible(float time){
        isInvincible = true;
        anim.SetBool("isInvincible", true);

        yield return new WaitForSeconds(time);

        isInvincible = false;
        anim.SetBool("isInvincible", false);
    }
}
