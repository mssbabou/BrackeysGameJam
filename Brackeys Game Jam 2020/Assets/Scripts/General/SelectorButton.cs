using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorButton : MonoBehaviour
{
    public int index;

    void Start(){
        if(FindObjectOfType<LevelManager>().unlockedLevels < index){
            GetComponent<Button>().interactable = false;
        }
    }
}
