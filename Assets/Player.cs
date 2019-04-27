using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FollowTarget))]
public class Player : MonoBehaviour {
    FollowTarget follow;
    public Controllable controllable;

    void Awake() {
        follow = GetComponent<FollowTarget>();
    }

    void Start() {
        if (controllable) {
            SetControllable(controllable);
        }
    }

    void SetControllable(Controllable controllable) {
        if (this.controllable) {
            this.controllable.MoveHorizontally(0);
        }
        this.controllable = controllable;
        if (controllable) {
            follow.target = controllable.transform;
            var mergeable = controllable.GetComponent<Mergeable>();
            if (mergeable) {
                mergeable.MergedInto += merged => SetControllable(merged.GetComponent<Controllable>());
            }
            var splitable = controllable.GetComponent<Splitable>();
            if (splitable) {
                splitable.Splitted += (first, second) => SetControllable(first.GetComponent<Controllable>());
            }
        }
    }

    void Update() {
        if (controllable) {
            var horizontalInput = Input.GetAxis("Horizontal");
            controllable.MoveHorizontally(horizontalInput);
            if (Input.GetButtonDown("Merge")) {
                controllable.Merge();
            }
            if (Input.GetButtonDown("Split")) {
                controllable.Split();
            }
        }
    }
}
