using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGuy : MonoBehaviour
{
    public float speed = 100.0f;
    public float currentSpeed;
    public float decreaseRatio = 0.1f;
    public float minDistance = 1.0f;
    public Transform[] waypoints;
    private int currentWaypoint;

    void Start()
    {
        currentSpeed = speed;
    }

    void Update()
    {
        Move();
        DecreaseSpeed();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < minDistance)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }

        float step = currentSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, step);
    }

    private void DecreaseSpeed()
    {
        if (currentSpeed > speed)
        {
            float decreaseValue = Time.deltaTime * Mathf.Sqrt(currentSpeed * decreaseRatio);
            currentSpeed -= decreaseValue;
            if (currentSpeed < speed)
            {
                currentSpeed = speed;
            }
        }
    }

    public void IncreaseSpeed(float value)
    {
        currentSpeed += value;
    }
}
