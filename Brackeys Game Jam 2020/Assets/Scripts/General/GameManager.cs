using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    bool paused;
    public Sprite pauseBtn;
    public Sprite pausedBtn;

    void Start(){
        Time.timeScale = 1;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause(){
        paused = !paused;
        pausePanel.SetActive(paused);
        if(paused){
            Time.timeScale = 0;
            GameObject.Find("PauseBtn").GetComponent<Image>().sprite = pausedBtn;
        }
        else{
            Time.timeScale = 1;
            GameObject.Find("PauseBtn").GetComponent<Image>().sprite = pauseBtn;
        }
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Pause();
        }
    }
}
