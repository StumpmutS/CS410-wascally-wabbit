using UnityEngine;

public class LevelRestartComponent : MonoBehaviour 
{
    public void Restart()
    {
        var levelCompleter = FindObjectOfType<LevelCompleter>();
        if (levelCompleter == null) return;
        
        levelCompleter.RestartLevel();
    }
}