using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: add to utilities
public class InputTorque : MonoBehaviour {
    public string axis = "Horizontal";
    public bool clockwise = true;
    public float maxTorque = 1;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void FixedUpdate() {
        var direction = clockwise ? -1 : 1;
        var input = Input.GetAxis(axis);
        rb.AddTorque(direction * input * maxTorque);
    }
}
