using UnityEngine;

public class LevelSkipper : MonoBehaviour
{
    [SerializeField] private LevelCompleter levelCompleter;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Backspace) && Input.GetKeyDown(KeyCode.Alpha0))
        {
            levelCompleter.CompleteLevel();
        }
    }
}
