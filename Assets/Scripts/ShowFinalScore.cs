using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFinalScore : MonoBehaviour
{

    void Start()
    {
        TextMeshProUGUI Text = GetComponent<TextMeshProUGUI>();
        Text.text = ScoreManager.Score.ToString();
    }
}
