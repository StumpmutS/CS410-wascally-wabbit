using UnityEngine;

public class ProgressionCompleter : MonoBehaviour
{
    public void CompleteProgression()
    {
        LevelManager.Instance.CompleteProgression();
    }
}