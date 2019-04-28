using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NugdeController : MonoBehaviour {
    public float deltaSpeed = 1f;
    Rigidbody2D rb;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Nudge() {
        if (rb.velocity.magnitude < 0.1f) {
            var direction = Random.insideUnitCircle.normalized;
            if (direction.y < 0) {
                direction = -direction;
            }
            rb.velocity = rb.velocity + direction * deltaSpeed;
        }
    }
}
