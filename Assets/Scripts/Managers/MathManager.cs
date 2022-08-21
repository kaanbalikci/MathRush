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
    [HideInInspector] public int no;

    public float countDown = 5;

    public string isTrue = null;

    public bool isPlayAnim;
    public bool isPlayCrush;
    public bool isPlus;
    public GameObject damageScreen;

    [SerializeField] private Transform truePOS;
    [SerializeField] private Transform falsePOS;

    [SerializeField] private TMP_Text trueAnswersText;
    [SerializeField] private TMP_Text falseAnswersText;

    [SerializeField] private GameObject falseAnswer;
    [SerializeField] private GameObject trueAnswer;

    [SerializeField] private TMP_Text question;

    

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

        int firstNumber = UnityEngine.Random.Range(2, 10);
        int secondNumber = UnityEngine.Random.Range(2, 10);
        int lastAnswer = firstNumber + secondNumber;
        int lastFalseAnswer = UnityEngine.Random.Range(lastAnswer - 2, lastAnswer + 2);

        if(lastFalseAnswer == lastAnswer)
        {
            lastFalseAnswer--;
        }

        trueAnswersText.text = lastAnswer.ToString();
        falseAnswersText.text = lastFalseAnswer.ToString();
        question.text = firstNumber.ToString() + " + " + secondNumber.ToString();
    }

    public void MediumQuestion()
    {
        SpawnAnswerObj();

        int firstNumber = UnityEngine.Random.Range(10, 20);
        int secondNumber = UnityEngine.Random.Range(10, 20);
        int lastAnswer = firstNumber + secondNumber;
        int lastFalseAnswer = UnityEngine.Random.Range(lastAnswer - 3, lastAnswer + 3);

        if (lastFalseAnswer == lastAnswer)
        {
            lastFalseAnswer--;
        }

        trueAnswersText.text = lastAnswer.ToString();
        falseAnswersText.text = lastFalseAnswer.ToString();
        question.text = firstNumber.ToString() + " + " + secondNumber.ToString();
    }

    public void HardQuestion()
    {
        SpawnAnswerObj();

        int firstNumber = UnityEngine.Random.Range(3, 9);
        int secondNumber = UnityEngine.Random.Range(3, 9);
        int lastAnswer = firstNumber * secondNumber;
        int lastFalseAnswer = UnityEngine.Random.Range(lastAnswer - 5, lastAnswer + 5);

        if (lastFalseAnswer == lastAnswer)
        {
            lastFalseAnswer--;
        }

        trueAnswersText.text = lastAnswer.ToString();
        falseAnswersText.text = lastFalseAnswer.ToString();
        question.text = firstNumber.ToString() + " x " + secondNumber.ToString();
    }

    public void ExpertQuestion()
    {
        SpawnAnswerObj();

        int firstNumber = UnityEngine.Random.Range(5, 9);
        int secondNumber = UnityEngine.Random.Range(5, 9);
        int thirdNumber = UnityEngine.Random.Range(2, 7);
        int lastAnswer = (firstNumber * secondNumber) + thirdNumber;
        int lastFalseAnswer = UnityEngine.Random.Range(lastAnswer - 5, lastAnswer + 5);

        if (lastFalseAnswer == lastAnswer)
        {
            lastFalseAnswer--;
        }

        trueAnswersText.text = lastAnswer.ToString();
        falseAnswersText.text = lastFalseAnswer.ToString();
        question.text = "(" + firstNumber.ToString() + " x " + secondNumber.ToString() + ") + " + thirdNumber.ToString();
    }

    public void DoubleExpertQuestion()
    {
        SpawnAnswerObj();

        int firstNumber = UnityEngine.Random.Range(3, 10);
        int secondNumber = UnityEngine.Random.Range(3, 10);
        int thirdNumber = UnityEngine.Random.Range(1, 5);
        int fourthNumber = UnityEngine.Random.Range(1, 5);
        int lastAnswer = (firstNumber * secondNumber) + (thirdNumber * fourthNumber);
        int lastFalseAnswer = UnityEngine.Random.Range(lastAnswer - 10, lastAnswer + 10);

        if (lastFalseAnswer == lastAnswer)
        {
            lastFalseAnswer--;
        }

        trueAnswersText.text = lastAnswer.ToString();
        falseAnswersText.text = lastFalseAnswer.ToString();
        question.text = "(" + firstNumber.ToString() + " x " + secondNumber.ToString() + ") + " + "(" + thirdNumber.ToString() + " x " + fourthNumber.ToString() + ")";
    }

    private void SpawnAnswerObj()
    {
        no = UnityEngine.Random.Range(0, 2);

        trueA = Instantiate(trueAnswer,truePOS.position,Quaternion.identity);
        falseA = Instantiate(falseAnswer,falsePOS.position,Quaternion.identity);


        if (no == 0)
        {
            trueA.transform.position = new Vector3(trueA.transform.position.x, trueA.transform.position.y, truePOS.transform.position.z);
            falseA.transform.position = new Vector3(falseA.transform.position.x, falseA.transform.position.y, falsePOS.transform.position.z);

            trueAnswersText.rectTransform.localPosition = new Vector3(trueAnswersText.transform.localPosition.x, trueAnswersText.transform.localPosition.y, leftZ);
            falseAnswersText.rectTransform.localPosition = new Vector3(falseAnswersText.transform.localPosition.x, falseAnswersText.transform.localPosition.y, rightZ);
        }
        else
        {
            trueA.transform.position = new Vector3(trueA.transform.position.x, trueA.transform.position.y, falsePOS.transform.position.z);
            falseA.transform.position = new Vector3(falseA.transform.position.x, falseA.transform.position.y, truePOS.transform.position.z);

            trueAnswersText.rectTransform.localPosition = new Vector3(trueAnswersText.transform.localPosition.x, trueAnswersText.transform.localPosition.y, rightZ);
            falseAnswersText.rectTransform.localPosition = new Vector3(falseAnswersText.transform.localPosition.x, falseAnswersText.transform.localPosition.y, leftZ);
        }
    }
    


}
