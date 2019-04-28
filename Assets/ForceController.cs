using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour {
    public float direction = 0;
    public float maxForce = 0.5f;

    Rigidbody2D rb;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveHorizontally(float d) {
        direction = d;
    }

    void FixedUpdate() {
        rb.AddForce(Vector2.right * direction * maxForce);
    }
}
