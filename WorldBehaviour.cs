using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBehaviour : MonoBehaviour
{
    public GameObject cell;
    public GameObject building;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 start = transform.position;

        for ( int i = -3; i < 3; i++)
        {
            for ( int j = -3; j < 3; j++)
            {
                start.x = i*10;
                start.z = j*10;
                Instantiate(cell, start, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildingCreate()
    {
        Instantiate(building);
    }
}
