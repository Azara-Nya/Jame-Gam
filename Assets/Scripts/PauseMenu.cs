using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    [SerializeField] private GameObject PauseMenuUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        GameIsPause = false;
    }

    public void LoadMenu()
    {
        GameIsPause = false;
        Time.timeScale = 1f;
        //load scene
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

}
