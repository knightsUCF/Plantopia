using UnityEngine;
using System.Collections;




public class Data : Singleton<Data>
{


    // menu

    public enum ButtonSelection
    {
        BlueCube,
        GreenCube
    }

    public static ButtonSelection buttonSelection;



    // tokens

    public static int tokens = 100;



    // tilling 

    public static Vector3 tillingSpot = new Vector3(0.0f, 0.0f, 0.0f);








    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

}
