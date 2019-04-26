using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float xSpeed = 0;
    public float ySpeed = 0;
    public float zSpeed = 100;
    void Update()
    {
        float dt = Time.deltaTime;
        transform.Rotate(xSpeed * dt, ySpeed * dt, zSpeed * dt);
    }
}
