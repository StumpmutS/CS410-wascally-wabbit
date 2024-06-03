using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused;
    public GameObject pauseMenuPrefab;
    private GameObject pauseMenuInstance;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
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
        if(pauseMenuInstance != null)
        {
            pauseMenuInstance.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    void Pause()
    {
        if(pauseMenuInstance == null)
        {
            pauseMenuInstance = Instantiate(pauseMenuPrefab);
            pauseMenuInstance.SetActive(true);
        }
        else
        {
            pauseMenuInstance.SetActive(true);
        }
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}