using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    static int score;

    [SerializeField] GameObject ScorePrefab;

    TextMeshProUGUI text;

    Camera mainCamera;
    public float LevelScoreBooster = 1;

    public static int Score { get => score;}

    private void Awake()
    {
        Instance = this;
        text = GetComponent<TextMeshProUGUI>();
        mainCamera = Camera.main;
        score = 0;
    }


    public void AddScore(int points, Vector3 position)
    {
        points = (int)(points * LevelScoreBooster);
        score += points;
        CreateOnScreenPoints(points, position);
        UpdateScore();
    }

    void UpdateScore()
    {
        text.text = score.ToString();
    }


    void CreateOnScreenPoints(int points, Vector3 position)
    {
        GameObject onScreenScore = Instantiate(ScorePrefab, transform.parent);
        TextMeshProUGUI text = onScreenScore.GetComponent<TextMeshProUGUI>();
        text.text = points.ToString();

        text.DOFade(0, 0.5f).OnComplete(() =>
        {
            Destroy(onScreenScore);
        });
        onScreenScore.transform.position = mainCamera.WorldToScreenPoint(position); ;
        onScreenScore.transform.DOPunchPosition(Vector3.up * 10, 0.5f, 2, 0.5f);

    }

}
