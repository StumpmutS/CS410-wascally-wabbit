using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public void Resume()
    {
        var pauseMenu = FindObjectOfType<PauseMenu>();
        if (pauseMenu == null) return;
        
        pauseMenu.Resume();
    }
    
    public void Menu()
    {
        var pauseMenu = FindObjectOfType<PauseMenu>();
        if (pauseMenu == null) return;
        
        pauseMenu.LoadMenu();
    }
}