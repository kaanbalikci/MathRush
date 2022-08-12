using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        LayerCheck();
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

    private void LayerCheck()
    {
        Collider[] insightRange = Physics.OverlapSphere(this.transform.position, 0.5f, interactable);

        if (insightRange.Length > 0)
        {
            if (insightRange[0].gameObject.CompareTag("GlassWall"))
            {
                Debug.Log("Hello");
            }
        }

    }
}
