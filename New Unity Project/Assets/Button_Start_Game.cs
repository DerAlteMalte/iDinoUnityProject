using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Start_Game : MonoBehaviour
{
    public void PlayGame(){
        //todo: load last scene visited
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void DeleteSaveData(){
        PlayerPrefs.SetInt("0", 0);
        PlayerPrefs.SetInt("1", 0);
        PlayerPrefs.SetInt("2", 0);
        PlayerPrefs.SetInt("3", 0);
    }
}
