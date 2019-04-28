using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerWhenPlayerEnters : MonoBehaviour {
    public UnityEvent entered;
    Player player;
    Collider2D bounds;

    void Start() {
        bounds = GetComponent<Collider2D>();
        player = FindObjectOfType(typeof(Player)) as Player;
    }
    void Update() {
        if (bounds.OverlapPoint(player.transform.position)) {
            entered?.Invoke();
            Debug.Log("Player entered " + this.gameObject);
        }
    }
}
