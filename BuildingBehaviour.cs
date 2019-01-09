using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour
{
    private float nextActionTime;
    private CameraBehaviour cameraBehavior;
    private GameObject entrance;

    public float periodTime = 0.2f;
    public float scrollSpeed = 5000;
    public int maxUnitCount = 3;
    public int currentUnitCount = 0;
    public int isInstantiate;
    public GameObject unit;

    List<GameObject> unitList;

    // Start is called before the first frame update
    void Start()
    {
        cameraBehavior = Camera.main.GetComponent<CameraBehaviour>();
        isInstantiate = 0;
        nextActionTime = Time.time + periodTime;
        unitList = new List<GameObject>();

        foreach (Transform child in transform)
        {
            if (child.name == "Entrance")
            {
                entrance = child.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInstantiate == 1)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += periodTime;
                if (currentUnitCount < maxUnitCount)
                {
                    currentUnitCount++;
                    unitList.Add((GameObject)Instantiate(unit, entrance.transform.position + new Vector3(0, -0.225f, 0), Quaternion.identity));
                }
            }
        }
        else
        {
            Vector3 offset = new Vector3(0, 1.5f, 0);
            transform.position = cameraBehavior.terrainHit + offset;

            if (Input.GetMouseButtonDown(0))
            {
                isInstantiate = 1;
            }

            transform.Rotate(0, (Input.GetAxis("Mouse ScrollWheel")) * Time.deltaTime * scrollSpeed, 0, Space.World);
        }
    }
}
