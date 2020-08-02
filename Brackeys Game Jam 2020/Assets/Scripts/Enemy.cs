﻿using System.Collections;
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

    void FixedUpdate(){
        Vector3 pos = new Vector3(transform.position.x, canvas.transform.position.y, 0);
        canvas.transform.position = pos;
    }
}
