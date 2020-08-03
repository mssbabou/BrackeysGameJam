using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool paused;

    void Start(){
        Time.timeScale = 1;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause(){
        paused = !paused;
        if(paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Pause();
        }
    }
}
