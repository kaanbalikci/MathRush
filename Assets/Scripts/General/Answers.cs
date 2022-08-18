using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public static Answers ans;

    [SerializeField] private Answer answ;

    

    public int answerNo;


    private void Awake()
    {
        ans = this;
    }
    void Start()
    {
        answerNo = answ.answerNo;
    }

    
    void Update()
    {
        
    }

    public void CloseCollider()
    {
        this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        Destroy(this.gameObject, 2);
    }


}
