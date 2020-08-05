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

    private GameObject nextLevelUI;

    void Awake(){
        if(!dontDestroyOnLoad){
            dontDestroyOnLoad = true;
            DontDestroyOnLoad(this);
        }
        nextLevelUI = GameObject.Find("Canvas").transform.Find("NextLevel").gameObject;
        unlockedLevels = PlayerPrefs.GetInt("Unlocked");
    }

    public void LevelFinished(){
        currentLevel++;
        if(unlockedLevels <= currentLevel){
            unlockedLevels = currentLevel + 1;
        }
        PlayerPrefs.SetInt("Unlocked", unlockedLevels);
        levelName = "Level" + currentLevel.ToString();
        
        Invoke("Invoked", 2f);
    }

    void Invoked(){
        nextLevelUI = GameObject.Find("Canvas").transform.Find("NextLevel").gameObject;
        nextLevelUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadLevel(string _levelName){
        SceneManager.LoadScene(levelName);
    }
}
