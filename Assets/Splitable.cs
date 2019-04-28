using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitable : MonoBehaviour {
    public event Action<GameObject, GameObject> Splitted;
    public GameObject part;
    public void Split() {
        var rb = GetComponentInParent<Rigidbody2D>();
        Vector3 direction = rb.velocity.normalized;
        var offset = direction * 0.5f;
        var pos = transform.position;
        var first = SpawnPart(pos + offset, rb.velocity);
        var second = SpawnPart(pos, rb.velocity);
        Splitted?.Invoke(first, second);
        Destroy(this.gameObject);
    }

    GameObject SpawnPart(Vector3 position, Vector2 velocity) {
        var p = Instantiate(part, position, transform.rotation);
        p.GetComponent<Rigidbody2D>().velocity = velocity;
        return p;
    }
}
