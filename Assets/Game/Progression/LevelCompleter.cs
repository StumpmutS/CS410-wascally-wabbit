using UnityEngine;

public class LevelCompleter : MonoBehaviour
{
    [SerializeField] private int levelIndex;
    
    public void CompleteLevel()
    {
        LevelManager.Instance.CompleteLevel(levelIndex);
    }

    public void RestartLevel()
    {
        LevelManager.Instance.RestartLevel(levelIndex);
    }
}