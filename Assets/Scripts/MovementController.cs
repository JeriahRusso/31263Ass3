using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 1f;

    private Transform target;
    private Vector3 direction;
    private int currentIndex = 1;

    void Start()
    {
        foreach(Transform t in waypoints)
        {
            t.position = new Vector3(t.position.x, t.position.y, transform.position.z);
        }
        target = waypoints[currentIndex];
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            currentIndex += 1;
            currentIndex %= waypoints.Length;
            target = waypoints[currentIndex];
            transform.Rotate(new Vector3(0f, 0f, 90f));
        }
        direction = target.position - transform.position;
        direction.z = 0;
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
