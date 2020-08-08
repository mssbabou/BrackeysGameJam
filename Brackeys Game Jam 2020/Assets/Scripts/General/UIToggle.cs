using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIToggle : MonoBehaviour
{
    private bool activated = true;

    public Sprite yes;
    public Sprite no;

    public bool musicToggle;

    void Start(){
        if(musicToggle)
            activated = !FindObjectOfType<MusciManager>().mute;
        else
            activated = !FindObjectOfType<MusciManager>().muteSFX;
    }

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
