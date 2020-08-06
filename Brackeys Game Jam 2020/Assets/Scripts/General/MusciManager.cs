using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusciManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject inGame;
    public GameObject boss;

    public bool mute;

    void Update(){
        string sceneName = SceneManager.GetActiveScene().name;
        if(sceneName.Contains("Level")){
            inGame.SetActive(true);
            boss.SetActive(false);
            menu.SetActive(false);
        }else if(sceneName.Contains("Boss")){
           boss.SetActive(true);
           inGame.SetActive(false);
           menu.SetActive(false);
        }else{
            menu.SetActive(true);
            boss.SetActive(false);
            inGame.SetActive(false);
        }
        menu.GetComponent<AudioSource>().mute = mute;
        inGame.GetComponent<AudioSource>().mute = mute;
        boss.GetComponent<AudioSource>().mute = mute;
    }
}
