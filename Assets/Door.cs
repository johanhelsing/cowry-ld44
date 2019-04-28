using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public bool open = false;
    public float force = 15;
    Rigidbody2D rb;
    AudioSource audioSource;

    void Start() {
        rb = GetComponentInChildren<Rigidbody2D>();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    public void Open() {
        open = true;
        audioSource?.Play();
    }
    public void Close() {
        open = false;
        audioSource?.Stop();
    }

    void FixedUpdate() {
        if (open) {
            rb.AddForce(Vector2.up * force);
        }
    }
}
