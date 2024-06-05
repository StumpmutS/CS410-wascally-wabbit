using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int levelCount;
    [SerializeField] private int menuSceneIndex;
    [SerializeField] private int progressionSceneIndex;
    [SerializeField] private int gameoverSceneIndex;
    [SerializeField] private SerializableDictionary<int, int> levelSceneIndexes;
    
    public int CurrentLevelIndex { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void CompleteLevel(int index)
    {
        if (index != CurrentLevelIndex) return;
        
        CurrentLevelIndex++;

        SceneManager.LoadScene(CurrentLevelIndex >= levelCount ? menuSceneIndex : progressionSceneIndex);
    }

    public void RestartLevel(int index)
    {
        if (index != CurrentLevelIndex) return;
        
        SceneManager.LoadScene(gameoverSceneIndex);
    }

    public void CompleteProgression()
    {
        if (SceneManager.GetActiveScene().buildIndex != progressionSceneIndex) return;
        
        SceneManager.LoadScene(levelSceneIndexes[CurrentLevelIndex]);
    }
}