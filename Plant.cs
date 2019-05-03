using System.Collections;                              // use strong verbs for methods: OnX, SetX, ShowX, UpdateX
using System.Collections.Generic;
using UnityEngine;














public class Plant : MonoBehaviour
{

    // different plant "empty of objects parent" prefabs with code on them so we can do: GetComponent<OfChild>
    // this way each of the prefabs (ex. potato) will have the 3 slots for the growth stages (up to as many growth stages as needed)

    public GameObject Potato; // drag in the prefab with the script
    public GameObject Corn;
    public GameObject Onions;


    // PLANT TYPE - set the plant type based on the menu choice -- data approach Data.SelectionX
    // based on the plant types we can do custom stuff with the Plant data object -- "Data Oriented Design"
    // then here we set the type for data recognition

    public enum PlantType
    {
        Potatoes,
        Corn,
        Onions
    }

    public static PlantType plantType;



    // GROWTH STAGES prefab models -- eventually once organized loading from assets will be quicker if something changes in the hierarchy and resets all the inspector slots

    // could this be somehow simplified by having the 3 stages on one data class?

    // or perhaps the Plant class calls the Potato class -- depending on the type

    /*
    
    if (enumType = PlantType.Potatoes)
    {
        // do potatoe stuff

        // make an object of the class

        potato.runStuff(); 

        // potato contains the three game fabs as a prefab? then we get the script with GetComponent<OfChild>

        // then we would define the game objects on top

        GameObject Potato; // drag in the prefab with the script
        GameObject Corn;
        GameObject Onions;

    }
    
    
    
    
    
    */

    

   
    
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
