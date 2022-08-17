using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BreakableObjScript : MonoBehaviour
{   
    [SerializeField] private GameObject allItems;
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject piece;
   

    public List<GameObject> pieces = new List<GameObject>();
   


    IEnumerator OpenTrigger()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < pieces.Count; i++)
        {
            pieces[i].GetComponent<BoxCollider>().isTrigger = true;
            Destroy(allItems,0.9f);
        }
        
    }

    private void Start()
    {
        Destroy(this.gameObject, 30);
    }

    private void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            cube.SetActive(false);
            piece.SetActive(true);
            Destroy(this.GetComponent<BoxCollider>());
            StartCoroutine(OpenTrigger());
        }
    }

    public void BreakThis()
    {
        cube.SetActive(false);
        piece.SetActive(true);
        Destroy(this.GetComponent<BoxCollider>());
        StartCoroutine(OpenTrigger());
    }

}
