using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text countDownText;

    private void OnEnable()
    {
        MathManager.UpdateTime += CountDownTime;
        MathManager.UpdateScore += ScoreManager;
    }
    private void OnDisable()
    {
        MathManager.UpdateTime -= CountDownTime;
        MathManager.UpdateScore -= ScoreManager;
    }


    public void ScoreManager(int Score)
    {
        scoreText.text = Score.ToString();
    }

    public void CountDownTime(float CountTime)
    {
        countDownText.text = Mathf.FloorToInt(CountTime).ToString();
    }
   
}
