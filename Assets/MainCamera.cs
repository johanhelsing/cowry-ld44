using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FollowTargetSmoothed))]
public class MainCamera : MonoBehaviour {
    public Player player;
    private FollowTargetSmoothed follow;
    void Start() {
        follow = GetComponent<FollowTargetSmoothed>();
    }

    void SearchForPlayer() {
        if (!player) {
            player = FindObjectOfType(typeof(Player)) as Player;
        }
    }

    void Update() {
        SearchForPlayer();
        follow.target = player.transform;
    }
}
