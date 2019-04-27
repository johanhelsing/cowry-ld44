using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerWhenPlayerEnters : MonoBehaviour {
    public UnityEvent entered;
    void OnTriggerEnter2D(Collider2D other) {
        entered?.Invoke();
        Debug.Log("Somthing entered " + other);
    }
}
