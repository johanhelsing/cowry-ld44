using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class FadeInTextMeshPro : MonoBehaviour {
    public bool useInitialValueAsTarget = true;
    public bool startAtZero = true;
    public float duration = 3;
    public AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);

    TextMeshPro tmp;
    private float targetAlpha = 1;
    private float startAlpha = 0;

    void Start() {
        tmp = GetComponent<TextMeshPro>();
        if (useInitialValueAsTarget) {
            targetAlpha = tmp.alpha;
        }
        if (!startAtZero) {
            startAlpha = tmp.alpha;
        } else {
            tmp.alpha = 0;
        }
    }

    public void StartFadeIn() {
        Debug.Log("should start to fade in ");
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn() {
        float timeLeft = duration;
        while (tmp.alpha != targetAlpha) {
            var t = curve.Evaluate((duration - timeLeft) / duration);
            tmp.alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            yield return null;
            timeLeft -= Time.deltaTime;
        }
    }
}
