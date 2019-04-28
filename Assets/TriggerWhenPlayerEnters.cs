using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerWhenPlayerEnters : MonoBehaviour {
    public UnityEvent entered;
    Player player;
    Collider2D bounds;
    bool hasEntered = false;

    void Start() {
        bounds = GetComponent<Collider2D>();
        player = FindObjectOfType(typeof(Player)) as Player;
    }

    void Update() {
        if (hasEntered) {
            return;
        }
        if (bounds.OverlapPoint(player.transform.position)) {
            hasEntered = true;
            entered?.Invoke();
        }
    }
}
