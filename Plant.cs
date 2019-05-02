using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Plant : MonoBehaviour
{
    



    // use strong verbs for methods

	// OnX, SetX, ShowX, UpdateX


    // constructors

    public int ID;


    // data properties

    public GameObject[] colliders = null; // different colliders for different OnTrigger functionality

    

    



    // constructor

    public Plant(int id)
    {
        ID = id;

    }



    void Start()
    {
        Debug.Log("Plant.cs");
    }



}
