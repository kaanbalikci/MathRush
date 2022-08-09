using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjScript : MonoBehaviour
{
    [SerializeField] private GameObject allItems;
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject piece;

    public List<GameObject> pieces = new List<GameObject>();


    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.A))
        {

            cube.SetActive(false);
            piece.SetActive(true);
            StartCoroutine(OpenTrigger());
        }
       */

    }

    IEnumerator OpenTrigger()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < pieces.Count; i++)
        {
            pieces[i].GetComponent<BoxCollider>().isTrigger = true;
            Destroy(allItems,2);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            cube.SetActive(false);
            piece.SetActive(true);
            StartCoroutine(OpenTrigger());
        }
    }

}
