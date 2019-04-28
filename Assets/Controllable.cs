using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable : MonoBehaviour {
    TorqueController torque;
    ForceController forceController;
    Mergeable mergeable;
    Splitable splitable;
    NugdeController nudgeController;

    void Start() {
        torque = GetComponent<TorqueController>();
        mergeable = GetComponent<Mergeable>();
        splitable = GetComponent<Splitable>();
        forceController = GetComponent<ForceController>();
        nudgeController = GetComponent<NugdeController>();
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

    public void SpecialAction() {
        nudgeController?.Nudge();
    }
}
