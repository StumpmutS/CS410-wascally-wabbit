using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuraction = 1f;
    public GameObject player;

    public bool PlayerCaught = false;
    
    public Timer timeScript;

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
            EndLevel(true);
        }
        if (timeScript.outTime)
        {
            EndLevel(true);
        }
    }

    void EndLevel(bool Restart)
    {
        if(Restart)
        {
            SceneManager.LoadScene(0);
        }
    }
}
