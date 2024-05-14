using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuraction = 1f;
    public GameObject player;

    public bool PlayerCaught = false;
    
    public Timer timeScript;
    public Score scoreScript;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            PlayerCaught = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCaught)
        {
            EndLevel(true, false);
        }
        if (timeScript.outTime)
        {
            EndLevel(true, false);
        }
        if (scoreScript.current == scoreScript.win)
        {
            EndLevel(true, true);
        }
    }

    void EndLevel(bool Restart, bool win)
    {
        if(Restart)
        {
            if(win)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
