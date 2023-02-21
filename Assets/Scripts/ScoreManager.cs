using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    TextMeshProUGUI text;

    float score = 0;

    private void Awake()
    {
        Instance = this;
        text = GetComponent<TextMeshProUGUI>();
    }


    public void AddScore(float points)
    {
        score += points;
        UpdateScore();
    }

    void UpdateScore()
    {
        text.text = score.ToString();
    }




}
