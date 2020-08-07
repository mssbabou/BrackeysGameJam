using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    private float health;
    GameObject enemyContainer;

    private GameObject[] rockets;

    public Image healthBar;

    private Animator anim;

    [Header("Audio")]
    public AudioSource die;

    void Start(){
        health = maxHealth;
        healthBar.fillAmount = health;
        anim = GetComponent<Animator>();

        enemyContainer = GameObject.Find("Ranged Enemy Container");
    }

    public void TakeDamage(float amount){
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Projectile"){
            TakeDamage(FindObjectOfType<WeaponScript>().damage);
            if(health <= 0){
                Die();
            }
        }
        if(col.gameObject.tag == "Explosion"){
            Die();
        }
        if(col.gameObject.tag == "Killbox"){
            Die();
        }

        if(col.gameObject.tag == "Boulder")
        {
            Die();
        }
    }

    public void Die(){
        die.Play();
        anim.SetTrigger("Die");
        Destroy(gameObject, 3);
    }

}
