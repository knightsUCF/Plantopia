using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Plant : MonoBehaviour
{
    



    // use strong verbs for methods

	// OnX, SetX, ShowX, UpdateX


    public int ID;


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
