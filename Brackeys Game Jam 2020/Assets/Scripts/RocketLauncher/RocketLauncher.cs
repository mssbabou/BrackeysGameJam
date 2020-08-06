using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{    
    public GameObject rocket;
    public GameObject e;

    private bool touchingPlayer;

    private Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
    }

    void Update(){
        e.SetActive(touchingPlayer);

        if(touchingPlayer){
            if(Input.GetKeyDown(KeyCode.E)){
                rocket.GetComponent<Rocket>().Fire();
                anim.SetTrigger("Use");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            touchingPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            touchingPlayer = false;
        }
    }
}