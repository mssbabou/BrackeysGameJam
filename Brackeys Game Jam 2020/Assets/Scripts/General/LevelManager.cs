using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int unlockedLevels;

    public int currentLevel;
    public string levelName;
    public bool dontDestroyOnLoad;

    void Awake(){
        if(!dontDestroyOnLoad){
            dontDestroyOnLoad = true;
            DontDestroyOnLoad(this);
        }
        unlockedLevels = PlayerPrefs.GetInt("Unlocked");
        string scenename = SceneManager.GetActiveScene().name;
        if(scenename.Contains("Level")){
        }
    }

    public void LevelFinished(){
        currentLevel = FindObjectOfType<GameManager>().currentLevel;
        if(unlockedLevels <= currentLevel){
            unlockedLevels = currentLevel;
        }
        PlayerPrefs.SetInt("Unlocked", unlockedLevels);
        levelName = "Level" + currentLevel.ToString();
        
        Invoke("Invoked", 2);
    }

    void Invoked(){
        SceneManager.LoadScene("LevelFinished");
    }

    public void LoadLevel(string _levelName){
        SceneManager.LoadScene(levelName);
    }
}
