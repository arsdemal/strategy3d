using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private int speed = 15;

    private Vector3 dir;
    private int keyPressed;
    private int buildMode;

    public GameObject building;
    public Canvas canvas;
    public RaycastHit hit;
    public Vector3 terrainHit;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(canvas);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        LayerMask layerMask = LayerMask.GetMask("Terrain");
        Physics.Raycast(ray, out hit, 100.0f, layerMask);

        dir = Vector3.zero;
        keyPressed = 0;

        if (hit.collider != null)
        {
            terrainHit = hit.point;
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir += Vector3.forward;
            keyPressed = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            dir += Vector3.back;
            keyPressed = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir += Vector3.left;
            keyPressed = 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            dir += Vector3.right;
            keyPressed = 1;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (hit.collider != null && hit.collider.tag == "Building")
            {
                Debug.Log("Building");
            }
        }

        if (keyPressed == 1)
            transform.Translate(dir * Time.deltaTime * speed, Space.World);
    }
}
