using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Material pathMaterial;

    public float lerpTime;

    public Color startingColor;

    public Color blue;
    public Color purple;
    public Color white;
    public Color yellow;
    public Color gray;
    public Color black;
    public Color green;

    public UIManager UIManager;
    void Start() {
        pathMaterial.color = startingColor;
    }
    void Update() {

        ColorControl();

    }

    void ColorControl() {
        if (UIManager.score > 100 && UIManager.score < 200) {
            pathMaterial.color = Color.Lerp(pathMaterial.color, gray, lerpTime);
        } else if (UIManager.score > 200 && UIManager.score < 300) {
            pathMaterial.color = Color.Lerp(pathMaterial.color, yellow, lerpTime);
        } else if (UIManager.score > 300 && UIManager.score < 400) {
            pathMaterial.color = Color.Lerp(pathMaterial.color, black, lerpTime);
        } else if (UIManager.score > 400 && UIManager.score < 500) {
            pathMaterial.color = Color.Lerp(pathMaterial.color, white, lerpTime);
        } else if (UIManager.score > 500 && UIManager.score < 600) {
            pathMaterial.color = Color.Lerp(pathMaterial.color, blue, lerpTime);
        } else if (UIManager.score > 600 && UIManager.score < 700) {
            pathMaterial.color = Color.Lerp(pathMaterial.color, green, lerpTime);
        } else if (UIManager.score > 700 && UIManager.score < 800) {
            pathMaterial.color = Color.Lerp(pathMaterial.color, purple, lerpTime);
        }

    }
}

