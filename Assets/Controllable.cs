using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable : MonoBehaviour {
    private TorqueController torque;
    private ForceController forceController;
    private Mergeable mergeable;
    private Splitable splitable;

    void Start() {
        torque = GetComponent<TorqueController>();
        mergeable = GetComponent<Mergeable>();
        splitable = GetComponent<Splitable>();
        forceController = GetComponent<ForceController>();
    }

    public void MoveHorizontally(float direction) {
        torque?.MoveHorizontally(direction);
        forceController?.MoveHorizontally(direction);
    }

    public void Merge() {
        mergeable?.Merge();
    }

    public void Split() {
        splitable?.Split();
    }
}
