using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tokens : MonoBehaviour
{


    public Text text;


    void Update()
    {
        text.text = Data.tokens.ToString();
    }
}
