using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonHandler : MonoBehaviour
{
    public void OnClickBlue()
    {
        Data.buttonSelection = Data.ButtonSelection.BlueCube;
    }


    public void OnClickGreen()
    {
        Data.buttonSelection = Data.ButtonSelection.GreenCube;
    }
}
