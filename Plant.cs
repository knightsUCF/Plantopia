using System.Collections;                              // use strong verbs for methods: OnX, SetX, ShowX, UpdateX
using System.Collections.Generic;
using UnityEngine;






public class Plant : MonoBehaviour
{

    // type

    public enum PlantType
    {
        Potatoes,
        Corn,
        Onions
    }

    public static PlantType plantType;



    // growth stage prefab models -- eventually once organized loading from assets will be quicker if something changes in the hierarchy and resets all the inspector slots

    public GameObject PotatoesGrowthStage0;
    public GameObject PotatoesGrowthStage1;
    public GameObject PotatoesGrowthStage2;


    public GameObject CornGrowthStage0;
    public GameObject CornGrowthStage1;
    public GameObject CornGrowthStage2;

    
    public GameObject OnionsGrowthStage0;
    public GameObject OnionsGrowthStage1;
    public GameObject OnionsGrowthStage2;

   
    
    // colliders for actions 

    public GameObject[] colliders = null;              // different colliders for different OnTrigger functionality


    // data 

    private Vector3 POS;                               
    private int GROWTH_STAGE;



    void Start()
    {
        Debug.Log("Plant.cs");
    }


    void Grow()
    {
        GROWTH_STAGE = 0;
        // GameObject someGO = Instatiate(GrowthStage0);
        StartGrowthCycle();
    }


    void StartGrowthCycle()
    {
        // run this every time period x that we want to grow, keep the time periods even for now

        // at every time period x we are goint to swap prefabs (destroy the old one)
    }

}
