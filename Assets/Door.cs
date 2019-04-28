using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public bool open = false;
    public float force = 15;
    public Rigidbody2D rb;

    void Start() {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    public void Open() {
        open = true;
    }
    public void Close() {
        open = false;
    }

    void FixedUpdate() {
        if (open) {
            rb.AddForce(Vector2.up * force);
        }
    }
}
