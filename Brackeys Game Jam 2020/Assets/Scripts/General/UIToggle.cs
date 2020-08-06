using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggle : MonoBehaviour
{
    private bool activated = true;

    public Sprite yes;
    public Sprite no;

    public void OnClick(){
        activated = !activated;
        if(activated){
            GetComponent<Image>().sprite = yes;
        }else{
            GetComponent<Image>().sprite = no;
        }
    }

    public void music(){
        GameObject.Find("MusicContainer").GetComponent<AudioSource>().mute = !activated;
    }
    public void sfx(){
        
    }
}
