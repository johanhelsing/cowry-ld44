using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueController : MonoBehaviour {
    public float direction = 0;
    public float maxTorque = 1;
    public bool clockwise = true;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    public void MoveHorizontally(float d) {
        direction = d;
    }

    void FixedUpdate() {
        var invert = clockwise ? -1 : 1;
        rb.AddTorque(direction * invert * maxTorque);
    }
}
