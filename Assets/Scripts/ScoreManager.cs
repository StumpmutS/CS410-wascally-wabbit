using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Utility;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private int win = 10;
    
    private int _current;
    public int Current
    {
        get => _current;
        set
        {
            _current = value;
            UpdateScore();
        }
    }

    public UnityEvent OnScoreFinish = new();

    public void UpdateScore()
    {
        scoreTxt.text = Current.ToString() + "/" + win.ToString();
        if (_current == win) OnScoreFinish.Invoke();
    }
}
