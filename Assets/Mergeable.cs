using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mergeable : MonoBehaviour {
    public event Action<GameObject> MergedInto;
    public enum Currency { Cowry, Coin };
    public Currency currency;
    public GameObject mergesInto;
    public float radius = 1f;

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
        Debug.Log("Trying to merge with " + other);
        var newPosition = (transform.position + other.transform.position) / 2;
        var newRotation = Quaternion.Lerp(transform.rotation, other.transform.rotation, 0.5f);
        var merged = Instantiate(mergesInto, newPosition, newRotation);
        MergedInto?.Invoke(merged);
        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }
}
