using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggle : MonoBehaviour
{
    private bool activated = true;

    private int playerprefs = 1;

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
        FindObjectOfType<MusciManager>().mute = !activated;
    }
    public void sfx(){
        FindObjectOfType<MusciManager>().muteSFX = !activated;
    }
}
