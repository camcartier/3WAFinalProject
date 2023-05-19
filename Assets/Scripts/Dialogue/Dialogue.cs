using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue 
{
    //this will be the name of the person speaking
    public string[] name;

    [TextArea(3, 10)]
    public string[] sentences;


}

