using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float timeLeft = 300;
    public TMP_Text timerTxt;

    public UnityEvent OnTimerFinish = new();
    
    // Update is called once per frame
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        UpdateTimer(timeLeft);
        
        if (timeLeft <= 0) OnTimerFinish.Invoke();
    }

    private void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
