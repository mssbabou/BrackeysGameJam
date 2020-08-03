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

    void Start(){
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
            col.gameObject.GetComponent<Enemy>().Die();
            TakeDamage(10);
        }
    }
}
