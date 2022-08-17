using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public static Ball _ball;

    private Rigidbody rb;

    [SerializeField] private LayerMask interactable;
    

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        _ball = this;
    }

    private void Update()
    {
       
        StartCoroutine(CloseBall());
    }

    public IEnumerator CloseBall()
    {
        yield return new WaitForSeconds(3f);
        transform.position = SpawnBall.SB.player.transform.position;
        this.gameObject.SetActive(false);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            MathManager.MM.score += 1;
        }
    }

  
}
