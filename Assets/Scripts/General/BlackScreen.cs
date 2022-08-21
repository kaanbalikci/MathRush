using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public static BlackScreen bs;

    [SerializeField] private GameObject crushText;
    [SerializeField] private GameObject plusText;

    private Animator crushAnim;
    private Animator anim;
    private Animator plusAnim;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        crushAnim = crushText.GetComponent<Animator>();
        plusAnim = plusText.GetComponent<Animator>();
    }

    private void Update()
    {
        if (MathManager.MM.isPlayAnim == true) 
        {
            anim.SetTrigger("fade");
            MathManager.MM.isPlayAnim = false;
        }

        if(MathManager.MM.isPlayCrush == true)
        {
            crushAnim.SetTrigger("crush");
            MathManager.MM.isPlayCrush = false;
        }

        if(MathManager.MM.isPlus == true && MathManager.MM.score != 0)
        {
            plusAnim.SetTrigger("plus");
            MathManager.MM.isPlus = false;
        }
   
    }
}
