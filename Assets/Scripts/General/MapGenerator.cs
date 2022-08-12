using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject plane;
    [SerializeField] private Transform player;

    private GameObject oldPlane = null;


    void Start()
    {
        
    }

    
    void Update()
    {
        SpawnNewPlane();

    }


    private void SpawnNewPlane()
    {
        if (((int)plane.transform.position.z - 50) == ((int)player.transform.position.z))
        {
            Vector3 newPos = new Vector3(plane.transform.position.x, plane.transform.position.y, plane.transform.position.z + 200);
            oldPlane = plane;
            plane = Instantiate(plane, newPos, Quaternion.identity);
        }

        if (((int)plane.transform.position.z - 80) == ((int)player.position.z))
        {
            Destroy(oldPlane);
        }
    }
}
