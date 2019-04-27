using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitable : MonoBehaviour {
    public event Action<GameObject, GameObject> Splitted;
    public GameObject part;
    public void Split() {
        var first = Instantiate(part, transform.position, transform.rotation);
        var second = Instantiate(part, transform.position, transform.rotation); // TODO: add some offset?
        Splitted?.Invoke(first, second);
        Destroy(this.gameObject);
    }
}
