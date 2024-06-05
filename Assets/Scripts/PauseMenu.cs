using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused;
    public GameObject pauseMenuPrefab;
    private GameObject pauseMenuInstance;
    private FPSControl fpsControl;
    private PewPew pewPew;


    void Start()
    {
        fpsControl = FindObjectOfType<FPSControl>();
        pewPew = FindObjectOfType<PewPew>();
    }

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
            fpsControl.enabled = true;
            pewPew.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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
        fpsControl.enabled = false;
        pewPew.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

}