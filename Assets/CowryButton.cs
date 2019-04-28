using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CowryButton : MonoBehaviour {
    public float force = 1;
    public float onThreshold = 0.1f;
    public Material pressedMaterial;
    public Material releasedMaterial;

    public UnityEvent pressed;
    public UnityEvent released;

    Light buttonLight;
    MeshRenderer meshRenderer;
    Rigidbody2D rb;
    bool isPressed = false;

    void Start() {
        rb = GetComponentInChildren<Rigidbody2D>();
        buttonLight = GetComponentInChildren<Light>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        UpdateColors();
    }

    void DoMovement() {
        if (rb.transform.localPosition.y > 0) {
            var local = rb.transform.localPosition;
            local.y = 0;
            rb.transform.localPosition = local;
            rb.velocity = Vector2.zero;
            return;
        }
        var f = rb.transform.localPosition.y > -0.05 ? 0.01f : force;
        rb.AddRelativeForce(Vector2.up * f);
    }

    void FixedUpdate() {
        DoMovement();
        SetPressed(rb.transform.localPosition.y < -onThreshold);
    }

    void SetPressed(bool newValue) {
        if (newValue == isPressed) {
            return;
        }
        isPressed = newValue;
        if (isPressed) {
            pressed?.Invoke();
        } else {
            released?.Invoke();
        }
        UpdateColors();
    }

    void UpdateColors() {
        buttonLight.enabled = isPressed;
        meshRenderer.material = isPressed ? pressedMaterial : releasedMaterial;
    }
}
