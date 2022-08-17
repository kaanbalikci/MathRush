using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{

    [SerializeField] private Answer answ;

    

    private int answerNo;
    void Start()
    {
        answerNo = answ.answerNo;
    }

    
    void Update()
    {
        
    }
}
