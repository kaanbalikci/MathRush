using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartUI : MonoBehaviour
{
    public static HeartUI HU;

    public GameObject Hearts;

    public int health = 4;


    [SerializeField] Image[] hearts;


    private void Awake()
    {
        HU = this;
    }

    void Update()
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i+1 > health)
            {
                hearts[i].color = Color.black;
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            health--;
        }
    




    }
}
