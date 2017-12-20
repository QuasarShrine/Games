using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{

    public float duration;

    private Image panel;
    private Color currentColor;

    [Tooltip("Is this a fade out effect ?")]
    public bool isFadeOut = false;

    // Use this for initialization
    void Start() {
        panel = GetComponent<Image>();
        currentColor.a = 1f;
        panel.color = currentColor;
    }

    // Update is called once per frame
    void Update() {
        if(Time.timeSinceLevelLoad < duration) {
            float alphaChange = Time.deltaTime / duration;
            currentColor.a -= alphaChange;
            panel.color = currentColor;
        } else {
            gameObject.SetActive(false);
        }
    }
}
