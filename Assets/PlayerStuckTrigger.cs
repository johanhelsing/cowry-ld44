using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStuckTrigger : MonoBehaviour {
    public float timeout = 15;

    float enteredTime = -1;

    Player player;
    Collider2D bounds;
    public UnityEvent playerStuck;

    void Start() {
        bounds = GetComponent<Collider2D>();
        player = FindObjectOfType(typeof(Player)) as Player;
        StartCoroutine(TriggerWhenPlayerStuck());
    }

    public IEnumerator TriggerWhenPlayerStuck() {
        while (true) {
            if (bounds.OverlapPoint(player.transform.position)) {
                if (enteredTime < 0) {
                    enteredTime = Time.time;
                }
                if (Time.time > enteredTime + timeout) {
                    playerStuck?.Invoke();
                    break;
                }
            } else {
                enteredTime = -1;
            }
            yield return null;
        }
    }
}
