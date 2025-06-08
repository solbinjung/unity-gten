using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlanet : MonoBehaviour
{
    public Vector3 StartPos;
    public float rotationSpeed = 1.0f;
    public float movementSpeed = 1.0f;
    public float oscillationSpeed = 2.0f; // 좌우로 움직이는 속도

    private void Start()
    {
        transform.position = StartPos;
    }

    private void Update()
    {
        // 회전
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // 좌우로 움직임
        float oscillation = Mathf.Sin(Time.time * oscillationSpeed);
        transform.Translate(Vector3.right * oscillation * movementSpeed * Time.deltaTime);
    }
}
