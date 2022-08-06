using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball _ball;
    private Rigidbody rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        _ball = this;
    }

    private void Start()
    {
        
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
        
    }

    /*public void ThrowBall()
    {
        Vector3 cubePos = new Vector3(SpawnBall.SB._cube.transform.position.x, SpawnBall.SB._cube.transform.position.y, SpawnBall.SB._cube.transform.position.z);
        Vector3 ballForcePoint = new Vector3(cubePos.x, cubePos.y + 0.2f, cubePos.z);
        rb.AddForce((ballForcePoint - this.transform.position) * 440f);
        SpawnBall.SB.isShot = false;

    }*/
}
