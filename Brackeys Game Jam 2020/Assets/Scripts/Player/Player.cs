using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 10;
    private int health;

    public GameObject hitFeedback;

    public Image healthBar;
    public Sprite[] healthBar_Sprites;

    private bool isInvincible;
    private Animator anim;
    private Animator camAnim;

    private GameObject deathPanel;

    void Start(){
        anim = GetComponent<Animator>();
        camAnim = GameObject.Find("MainCamera").GetComponentInChildren<Animator>();
        health = maxHealth;
        deathPanel = GameObject.Find("DeathPanel");
        //deathPanel.SetActive(false);
    }

    GameObject hit;
    public void TakeDamage(int amount){
        health -= amount;

        hit = Instantiate(hitFeedback);
        Destroy(hit, 0.15f);

        camAnim.SetTrigger("Shake");
        Invoke("CameraIdle", 2f);

        if(health <= 0){
            Die();
        }

        healthBar.sprite = healthBar_Sprites[health];
    }

    void CameraIdle(){
        camAnim.SetTrigger("Idle");
    }

    void Die(){
        deathPanel.SetActive(true);
        hit.SetActive(false);
        Time.timeScale = 0;
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Enemy"){
            if(isInvincible) return;
            TakeDamage(1);
            StartCoroutine(GoInvincible(2));
            col.gameObject.GetComponent<EnemyMovement>().Flip();
        }
        if(col.gameObject.tag == "Projectile"){
            if(isInvincible) return;
            TakeDamage(1);
            StartCoroutine(GoInvincible(2));
        }
        if(col.gameObject.tag == "Killbox"){
            Die();
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
