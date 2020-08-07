using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour
{
    private Animator anim;
    private bool open;
    public GameObject pressE;

    public delegate void GoneThroughDoor();
    public GoneThroughDoor PlayerFinishedLevel;

    private AudioSource audio;

    void Start(){
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            open = true;
            
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            open = false;
        }
    }

    void Update(){
        pressE.SetActive(open);
        if(open){
            anim.SetTrigger("Open");
            if(Input.GetKeyDown(KeyCode.E))
            {
                //audio.Play();
                FindObjectOfType<Player>().UseDoor();
                FindObjectOfType<LevelManager>().LevelFinished();
                PlayerFinishedLevel();
            }
        }
    }
}
