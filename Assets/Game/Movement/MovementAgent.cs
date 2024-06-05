using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MovementAgent : MonoBehaviour
{
    [SerializeField] private float destinationReachOffset = .1f;
    [SerializeField] private NavMeshAgent agent;

    private bool _pathSet;
    private Scene scene;
    private bool hasBeenShot = false;
    private bool canBeShot = true;
    public float timePause = 5;
    public float timeNum = 5;
    public float pauseReset = 5;
    public float pauseNum = 5;
    public float speedNum = 5;
    
    public UnityEvent<MovementAgent> OnDestinationReached = new();

    void Start(){
        scene = SceneManager.GetActiveScene();
    }
    
    public void SetDestination(Vector3 point)
    {
        point.y = Terrain.activeTerrain.SampleHeight(point);
        agent.SetDestination(point);
    }

    public void ClearDestination()
    {
        agent.ResetPath();
    }

    private void Update()
    {
        if (hasBeenShot)
        {
            timePause -= Time.deltaTime;
            if (timePause <= 0)
            {
                if(scene.name == "Level 3") speedNum += 1;
                timePause = timeNum;
                agent.speed = speedNum;
                hasBeenShot = false;
                canBeShot = false;
            }
        }
        if (canBeShot == false)
        {
            pauseReset -= Time.deltaTime;
            if (pauseReset <= 0)
            {
                pauseReset = pauseNum;
                canBeShot = true;
            }
        }
        
        if (!agent.enabled) return;
        if (agent.pathPending) return;
        if (agent.hasPath) _pathSet = true;
        if (!_pathSet) return;
        if (agent.remainingDistance >= destinationReachOffset) return;
        FinishPath();
    }

    private void FinishPath()
    {
        agent.ResetPath();
        _pathSet = false;
        OnDestinationReached.Invoke(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (canBeShot == true)// && pauseReset > 0)
            {
                agent.speed = 0;
                hasBeenShot = true;
            }
        }
    }
}