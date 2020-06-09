using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Library needed to access scenes

public class StartMenu : MonoBehaviour
{
    void Start(){

    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log ("Quit Button Pushed");
    }

    public void StartGame(){
        SceneManager.LoadScene("Main");
    }
}
