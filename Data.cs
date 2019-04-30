using UnityEngine;
using System.Collections;




public class Data : Singleton<Data>
{

    // public static int tokens = 100;

    public enum ButtonSelection
    {
        BlueCube,
        GreenCube
    }

    public static ButtonSelection buttonSelection;








    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

}
