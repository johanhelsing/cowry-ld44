using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour {
    public UnityEvent timedOut;
    public float duration = 5;
    public bool autoStart = true;
    public bool destroyOnTimeout = true;

    void Start() {
        if (autoStart) {
            StartTimer();
        }
    }

    public void StartTimer() {
        StartCoroutine(TriggerAfterTimeout());
    }

    IEnumerator TriggerAfterTimeout() {
        yield return new WaitForSeconds(duration);
        timedOut?.Invoke();
        if (destroyOnTimeout) {
            Destroy(this);
        }
    }
}
