using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Camera Cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cam.transform.position = this.transform.position;
        //this.transform.Translate(0, 0, speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("SA");
        }
    }
}
