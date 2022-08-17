using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class MathManager : MonoBehaviour
{
    public static MathManager MM;

    public static event Action<int> UpdateScore;
    public static event Action<float> UpdateTime;

    public int score = 0;
    public int no;
    private float countDown = 5;

    [SerializeField] private TMP_Text trueAnswersText;
    [SerializeField] private TMP_Text falseAnswersText;

    [SerializeField] private GameObject falseAnswer;
    [SerializeField] private GameObject trueAnswer;

    [SerializeField] private TMP_Text question;

    [SerializeField] private GameObject truePOS;
    [SerializeField] private GameObject falsePOS;

    //Answer Text rect transform Z pos
    private float leftZ = -4.347f;
    private float rightZ = -2.45f;

    //Answer Object transform Z pos
    private float leftAnswerZ = -66.71f;
    private float rightAnswerZ = -64.71f;

    private GameObject trueA;
    private GameObject falseA;

    private void Awake()
    {
        MM = this;
    }
    void Start()
    {
        EasyQuestion();
    }

  
    void Update()
    {
        UpdateScore?.Invoke(score);

        if (countDown > 0)
        {
            countDown -= Time.deltaTime;      
        }
        else
        {

        }
        UpdateTime?.Invoke(countDown);

        



    }


    public void EasyQuestion()
    {
        SpawnAnswerObj();

        int firstNumber = UnityEngine.Random.Range(2, 6);
        int secondNumber = UnityEngine.Random.Range(2, 6);
        int lastAnswer = firstNumber * secondNumber;
        int lastFalseAnswer = UnityEngine.Random.Range(lastAnswer - 5, lastAnswer + 5);

        if(lastFalseAnswer == lastAnswer)
        {
            lastFalseAnswer--;
        }

        trueAnswersText.text = lastAnswer.ToString();
        falseAnswersText.text = lastFalseAnswer.ToString();
        question.text = firstNumber.ToString() + " x " + secondNumber.ToString();



    }

    private void SpawnAnswerObj()
    {
        no = UnityEngine.Random.Range(0, 2);

        trueA = Instantiate(trueAnswer);
        falseA = Instantiate(falseAnswer);


        if (no == 0)
        {
            trueA.transform.position = new Vector3(trueA.transform.position.x, trueA.transform.position.y, leftAnswerZ);
            falseA.transform.position = new Vector3(falseA.transform.position.x, falseA.transform.position.y, rightAnswerZ);

            trueAnswersText.rectTransform.localPosition = new Vector3(trueAnswersText.transform.localPosition.x, trueAnswersText.transform.localPosition.y, leftZ);
            falseAnswersText.rectTransform.localPosition = new Vector3(falseAnswersText.transform.localPosition.x, falseAnswersText.transform.localPosition.y, rightZ);
        }
        else
        {
            trueA.transform.position = new Vector3(trueA.transform.position.x, trueA.transform.position.y, rightAnswerZ);
            falseA.transform.position = new Vector3(falseA.transform.position.x, falseA.transform.position.y, leftAnswerZ);

            trueAnswersText.rectTransform.localPosition = new Vector3(trueAnswersText.transform.localPosition.x, trueAnswersText.transform.localPosition.y, rightZ);
            falseAnswersText.rectTransform.localPosition = new Vector3(falseAnswersText.transform.localPosition.x, falseAnswersText.transform.localPosition.y, leftZ);
        }
    }
    

}
