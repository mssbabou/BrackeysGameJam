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

    public bool loaderScene;

    void Start(){
        Time.timeScale = 1;
        if(loaderScene){
            SceneManager.LoadScene("Level0");
        }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void FinishedRestart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<LevelManager>().currentLevel--;
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

    public void Load(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void NextLevel(){
        LevelManager l = FindObjectOfType<LevelManager>();
        l.LoadLevel(l.levelName);
    }
}
