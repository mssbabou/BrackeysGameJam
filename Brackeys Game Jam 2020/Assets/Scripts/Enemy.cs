using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject canvas;

    public float maxHealth;
    private float health;

    public Image healthBar;

    void Start(){
        health = maxHealth;
        healthBar.fillAmount = health;
    }
    
    void Update() {
        Vector2 pos = new Vector2();
        canvas.transform.position = transform.position;
    }

    public void TakeDamage(float amount){
        health -= amount;
        healthBar.fillAmount = health / maxHealth;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Projectile"){
            TakeDamage(FindObjectOfType<WeaponScript>().damage);
            if(health <= 0){
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
