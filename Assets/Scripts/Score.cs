using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] public TMP_Text scoreTxt;
    public int current;
    public int win = 10;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void updateScore()
    {
        scoreTxt.text = current.ToString() + " / " + win.ToString();
    }
}
