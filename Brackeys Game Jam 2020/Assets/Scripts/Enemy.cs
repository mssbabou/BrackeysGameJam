using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    private float health;
    GameObject enemyContainer;

    public Image healthBar;

    private Animator anim;

    void Start(){
        health = maxHealth;
        healthBar.fillAmount = health;
        anim = GetComponent<Animator>();

        enemyContainer = GameObject.Find("Ranged Enemy Container");

        transform.parent = enemyContainer.transform;
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
    }

    public void Die(){
        anim.SetTrigger("Die");
        Destroy(gameObject, 3);
    }
}
