using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGuy : MonoBehaviour
{
    public float speed = 100.0f;
    public float currentSpeed;
    public float decreaseRatio = 2.0f;
    public float minDistance = 1.0f;
    public List<Box> waypoints;
    private Transform destination;
    private bool bussy = false;
    public Transform home;
    public GameController gameController;

    void Start()
    {
        currentSpeed = speed;
    }

    void Update()
    {
        if (bussy)
        {
            Move();
        }
        else
        {
            goHome();
        }

        DecreaseSpeed();
    }

    private void Move()
    {
        if (waypoints[0] == null) 
        {
            waypoints.Remove(waypoints[0]);
            bussy = false;
        }
        else
        {
            float step = currentSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, waypoints[0].transform.position, step);
        }

        if (Vector3.Distance(transform.position, waypoints[0].transform.position) < minDistance)
        {
            Box box = waypoints[0];
            gameController.IncreaseCoins(box.GetValue());
            waypoints.Remove(box);
            Destroy(box.gameObject);
            bussy = false;
        }
    }

    private void goHome()
    {
        if (Vector3.Distance(transform.position, home.position) < minDistance && waypoints.Count > 0)
        {
            bussy = true;
        }
        else
        {
            float step = currentSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, home.position, step);
        }
    }

    private void DecreaseSpeed()
    {
        if (currentSpeed > speed)
        {
            float decreaseValue = Time.deltaTime * decreaseRatio;
            currentSpeed -= decreaseValue;
        }
    }

    public void IncreaseSpeed(float value)
    {
        currentSpeed += value;
    }

    public void AddDestination(Box destination)
    {
        waypoints.Add(destination);
    }
}
