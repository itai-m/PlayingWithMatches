using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FocusText : MonoBehaviour {
    [Range(1,20)]
    public int focuesNumber = 0;
    private int oldValue = 0;

    private Text text;
    private RectTransform rectTransform;

    private void Reset() {
        text = GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnValidate() {
        if (focuesNumber != oldValue) {
            if (oldValue != 0) {
                RemoveFocues(oldValue);
            }
            if (focuesNumber != 0) {
                UpdateFocues(focuesNumber);
            }
        }
        oldValue = focuesNumber;
    }

    private void UpdateSize(float value) {
        text.fontSize = (int)(text.fontSize * value);
        rectTransform.sizeDelta *= value;
        rectTransform.localScale /= value;
    }

    private void UpdateFocues(float value) {
        UpdateSize(value);
    }

    private void RemoveFocues(float value) {
        UpdateSize(Mathf.Pow(value, -1));
    }
}
