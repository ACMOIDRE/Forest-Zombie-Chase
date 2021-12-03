using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // [SerializeField] GameObject pauseMenu ;
    // public static bool GameIsPause = false;

    //  private bool isShowing;
    

    private void Update()
    {

        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     isShowing = !isShowing;
            

        //     if (isShowing  )
        //     {
        //         Pause();
                                
        //     } 
        //     else 
        //     {                
        //         Resume();
        //         GameIsPause = false;                
        //     }
            
        // }

    }

    // void Pause()
    // {
    //     pauseMenu.SetActive(true);
    //     GameIsPause = true;
    //     Time.timeScale = 0f;

    //     Debug.Log("pause");
    // }

    // public void Resume()
    // {
    //     Time.timeScale = 1f;
    //     pauseMenu.SetActive(false);

    //     Debug.Log("resume");
    // }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

        Debug.Log("main");
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        AudioListener.volume = 1;
        
    }

    
}