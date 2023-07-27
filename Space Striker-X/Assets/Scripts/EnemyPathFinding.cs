using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{  
    WaveConfig waveConfig;
    List<Transform> Waypoints;
    int waypointIndex = 0;

    void Start()
    {
        Waypoints = waveConfig.getWayPoints();
        transform.position = Waypoints[waypointIndex].transform.position;
    }
   
    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    private void EnemyMovement()
    {
       if (waypointIndex <= Waypoints.Count - 1)
        {
            var targetPosition = Waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.getMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}