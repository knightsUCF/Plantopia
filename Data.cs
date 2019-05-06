using UnityEngine;
using System.Collections;



// probably should be renaimed to State, since this will be unrelated now to DataBaseManager, or any sort of data connected with that class

// we can also initialize a custom starting state in a Start() method of this class -- for example we want the menu buttons toggled off, etc


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
