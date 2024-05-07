using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 300;
    public TMP_Text timerTxt;
    public bool outTime = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            updateTimer(timeLeft);
        }
        else
        {
            outTime = true;
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
