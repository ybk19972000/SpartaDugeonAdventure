using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button gameStart;
    public Button gameExit;

    public void Start()
    {
        
    }

    public void UpdateScore(float score)
    {
        scoreText.text = score.ToString();
    }
}
