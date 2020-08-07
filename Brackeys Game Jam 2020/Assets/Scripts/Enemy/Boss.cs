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

    private bool laserAttack = true;
    public float timeBtwShots;
    private float time;
    public GameObject laser;
    public Transform leftEye;
    public Transform rightEye;

    private bool finishHim;

    public GameObject finishHimSetup;
    public GameObject otherSetup;

    public GameObject winPanel;

    void Start(){
        anim = GetComponent<Animator>();
        health = maxHealth;
        healthBar_fill.fillAmount = health / maxHealth;
        player = GameObject.Find("Player");
        playerPos = new Vector2(player.transform.position.x + 1, player.transform.position.y);
        time = timeBtwShots;
    }

    void Update(){
        if(player.transform.position.x < transform.position.x){
            GetComponent<SpriteRenderer>().flipX = true;
        }else{
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if(laserAttack){
            time -= Time.deltaTime;
            if(time <= 0){
                time = timeBtwShots;
                Instantiate(laser, leftEye.position, Quaternion.identity);
                Instantiate(laser, rightEye.position, Quaternion.identity);
            }
        }
        if(health <= 1){
            finishHim = true;
            laserAttack = false;
            finishHimSetup.SetActive(true);
            otherSetup.SetActive(false);
        }
    }

    void TakeDamage(float amount){
        health -= amount;
        healthBar_fill.fillAmount = health / maxHealth;

        if(health <= 0){
            Die();
        }

        anim.SetTrigger("Hurt");
        Invoke("Idle", 0.15f);
    }

    void Die(){
        anim.SetTrigger("Die");
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach(AudioSource a in audios){
            a.mute = true;
        }
        Invoke("Win", 3);
    }

    void Win(){
        winPanel.GetComponent<AudioSource>().mute = false;
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    void Idle(){
        anim.SetTrigger("Idle");
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Rocket"){
            col.gameObject.GetComponent<Rocket>()._Explode();
            TakeDamage(1);
        }
    }
}
