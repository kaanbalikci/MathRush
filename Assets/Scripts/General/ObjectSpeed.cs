using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpeed : MonoBehaviour
{
    public static ObjectSpeed OS;

    [HideInInspector] public float allObjectSpeed = 6f;



    private void Awake()
    {
        OS = this;
    }

    private void FixedUpdate()
    {
        if (this.CompareTag("GlassWall"))
        {
            this.transform.Translate(allObjectSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            this.transform.Translate(0, 0, -allObjectSpeed * Time.deltaTime);
        }
    }
   
}
