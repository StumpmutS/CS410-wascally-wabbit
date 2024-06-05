using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDestroySpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private int _sceneIndex = -1;
    private bool _isQuitting;

    private void Awake()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    private void OnDestroy()
    {
        if (_isQuitting || SceneManager.GetActiveScene().buildIndex != _sceneIndex) return;

        Instantiate(prefab, transform.position, transform.rotation);
    }
}