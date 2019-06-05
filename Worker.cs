





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public GameObject model;
    public float speed = 1.0f;
    public float rotSpeed = 1.0f;


    // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
    // we could put an invisible collider on the field at the place we want the worker to till the land
    // we could have a few of these colliders at sensible locations where the workers would walk around the field and till the earth
    // the tilling spot might be blocked by something
    // so better that we register the tilling spot vector position, and just move toward that


    void Update()
    {

        // here is some code to avoid layers, is the method overriden? can we just not pass the layer

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;


        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");

            // here we can get where the field is

            // the problem is not to do a .tag collider inside an update

            // or perhaps we only call this once, when the ray is first sent out and encouters the object



            print(hit.collider.gameObject.name);
            print(hit.collider.tag);

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

        // transform.position += Vector3.up * speed;

        transform.Rotate(0, rotSpeed, 0);
    }



}

