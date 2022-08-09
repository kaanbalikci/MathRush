using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool objects;

    //BALL
    private List<GameObject> pooledObj = new List<GameObject>();
    private int ballPoolSize = 25;
    [SerializeField] private GameObject ballPrefab;

    //CUBE
    private List<GameObject> cubePooledObj = new List<GameObject>();
    private int cubePoolSize = 3;
    [SerializeField] private GameObject cubePrefab;
    
    private void Awake()
    {
        objects = this;
    }

    private void Start()
    {
        for (int i = 0; i < ballPoolSize; i++)
        {
            GameObject ballObj = Instantiate(ballPrefab);
            ballObj.SetActive(false);
            pooledObj.Add(ballObj);
        }

        for (int i = 0; i < cubePoolSize; i++)
        {
            GameObject cubeObj = Instantiate(cubePrefab);
            cubeObj.SetActive(false);
            cubePooledObj.Add(cubeObj);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < pooledObj.Count; i++)
        {
            if (!pooledObj[i].activeInHierarchy)
            {
                return pooledObj[i];
            }
        }

        return null;
    }

    public GameObject GetCubeObject()
    {
        for (int i = 0; i < cubePooledObj.Count; i++)
        {
            if (!cubePooledObj[i].activeInHierarchy)
            {
                return cubePooledObj[i];
            }
        }

        return null;
    }
}
