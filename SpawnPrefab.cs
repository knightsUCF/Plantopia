using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=appPNl_Q0xE




public class SpawnPrefab : MonoBehaviour
{

    public GameObject prefab;

    RaycastHit hit;



    void MouseSpawn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse clicked");
            // RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "platform")
                {
                    Instantiate(prefab, hit.point, Quaternion.identity);
                    print("spawning");
                }
            }
        }
    }



    void TouchSpawn()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began && hit.transform.name == "platform")
                Instantiate(prefab, touchPos, Quaternion.identity);
        }

    }



    void Update()
    {
        // MouseSpawn();
        TouchSpawn();
    }



}
