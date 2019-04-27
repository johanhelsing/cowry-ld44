using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetSmoothed : MonoBehaviour {
    public Transform target;
    public bool ignoreZ = true;
    public float speed = 5;
    void Update() {
        if (!target) {
            return;
        }
        var pos = target.transform.position;
        if (ignoreZ) {
            pos.z = transform.position.z;
        }
        var offset = pos - transform.position;
        transform.position = transform.position + offset * speed * Time.deltaTime;
    }
}
