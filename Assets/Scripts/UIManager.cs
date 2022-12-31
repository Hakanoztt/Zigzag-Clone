using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

    public TextMeshProUGUI scoreText;
    public int score;
    void Update() {
        scoreText.text = score.ToString();
    }
}
