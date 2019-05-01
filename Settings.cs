using UnityEngine;
using System.Collections;




public class Settings : Singleton<Settings>
{


    // building costs

    public static int BuildingCost = 10;





    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

}
