using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public float spawnTime = 0;
    public float diaSpawnTime = 0;

    //Plane
    [SerializeField] private GameObject plane;
    [SerializeField] private Transform player;
    private GameObject oldPlane = null;

    //Glass
    [SerializeField] private GameObject[] glass;
    private int whichGlass;

    //Diamonds
    [SerializeField] private GameObject[] Diamond;
    


    void Update()
    {
        SpawnNewPlane();

        SpawnNewGlass();

        if(diaSpawnTime == 0) { SpawnNewDiamond(); }
       

        if (spawnTime > 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else { spawnTime = 0; };

        if (diaSpawnTime > 0)
        {
            diaSpawnTime -= Time.deltaTime;
        }
        else { diaSpawnTime = 0; };

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

    private void SpawnNewGlass()
    {
        Vector3 glassSpawnPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 110);
        whichGlass = Random.Range(0, glass.Length);


        if(((int)player.transform.position.z) % 70 == 0 && spawnTime == 0)
        {
            GameObject newObj = Instantiate(glass[whichGlass], glassSpawnPos, Quaternion.identity);
            newObj.transform.Rotate(0, 90, 0);
            spawnTime = 4f;
        }
            
    }
    
    private void SpawnNewDiamond()
    {
        
        int RorL = Random.Range(0, 2); //right or left control
        int whichDia = Random.Range(0, Diamond.Length);

        if (RorL == 0)
        {

            Vector3 checkPos = new Vector3(Random.Range(-7f, -2f), Diamond[whichDia].transform.position.y, player.transform.position.z + 110);
            Instantiate(Diamond[whichDia], checkPos, Quaternion.identity);
            diaSpawnTime = 3;

        }

        if (RorL == 1)
        {
            Vector3 checkPos = new Vector3(Random.Range(7f, 2f), Diamond[whichDia].transform.position.y, player.transform.position.z + 110);
            Instantiate(Diamond[whichDia], checkPos, Quaternion.identity);
            diaSpawnTime = 3;
        }
    }

}
