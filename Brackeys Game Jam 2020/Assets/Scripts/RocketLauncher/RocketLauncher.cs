using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{    
    public GameObject rocket;
    public GameObject e;

    private bool touchingPlayer;

    private Animator anim;

    public bool finisherRockets;

    public bool canReload;
    public float reloadTime;
    private float time;
    private bool canShoot;

    [SerializeField]
    GameObject linkedButton;
    [SerializeField]
    public GameObject lastRocket1;
    public GameObject lastRocket2;

    void Start(){
        anim = GetComponent<Animator>();
    }

    void Update(){
        e.SetActive(touchingPlayer);

        if(touchingPlayer){
            if(Input.GetKeyDown(KeyCode.E)){
                if(!canShoot) return;
                rocket.GetComponent<Rocket>().Fire();
                anim.SetTrigger("Use");
            }
        }

        if(canReload){
            if(time <= 0){
                time = reloadTime;
                canShoot = true;
            }else{
                canShoot = false;
                time -= Time.deltaTime;
            }
        }

        if(!finisherRockets) return;
        linkedButton.GetComponent<WallButtonScript>().buttonActive += Activate1;
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

    private void Activate1()
    {
        lastRocket1.GetComponent<Rocket>().Fire();
        lastRocket2.GetComponent<Rocket>().Fire();
    }
}