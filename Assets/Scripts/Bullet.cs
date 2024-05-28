using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 0;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Rabbit")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ScoreManager.Instance.Current += 1;
            ScoreManager.Instance.UpdateScore();
        }
    }
}
