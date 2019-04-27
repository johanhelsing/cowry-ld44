using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable : MonoBehaviour {
    private TorqueController torque;
    private Mergeable mergeable;
    private Splitable splitable;

    void Start() {
        torque = GetComponent<TorqueController>();
        mergeable = GetComponent<Mergeable>();
        splitable = GetComponent<Splitable>();
    }

    public void MoveHorizontally(float direction) {
        torque?.MoveHorizontally(direction);
    }

    public void Merge() {
        mergeable?.Merge();
    }

    public void Split() {
        splitable?.Split();
    }
}
