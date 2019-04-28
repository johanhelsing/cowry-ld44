using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Mergeable : MonoBehaviour {
    public event Action<GameObject> MergedInto;
    public enum Currency { Cowry, Coin };
    public Currency currency;
    public GameObject mergesInto;
    public float radius = 1f;
    public Rigidbody2D rb;
    public UnityEvent WasMergedWithPlayer;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Merge() {
        var overlaps = Physics2D.OverlapCircleAll(transform.position, radius);

        var closest = overlaps.Select(o => o.GetComponent<Mergeable>())
            .Where(mergeable => mergeable && mergeable != this && mergeable.currency == currency)
            .OrderBy(m => (m.transform.position - transform.position).sqrMagnitude)
            .FirstOrDefault();

        if (closest) {
            MergeWith(closest);
        }
    }

    private void MergeWith(Mergeable other) {
        var newPosition = (transform.position + other.transform.position) / 2;
        var newRotation = Quaternion.Lerp(transform.rotation, other.transform.rotation, 0.5f);
        var newVelocity = (rb.velocity + other.rb.velocity) / 2;
        var merged = Instantiate(mergesInto, newPosition, newRotation);
        merged.GetComponent<Rigidbody2D>().velocity = newVelocity;
        MergedInto?.Invoke(merged);
        other.WasMergedWithPlayer?.Invoke();
        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }
}
