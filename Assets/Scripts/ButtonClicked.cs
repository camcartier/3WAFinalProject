using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClicked : MonoBehaviour
{
    public int clickNumber;

    public void IncrementClick()
    {
        clickNumber++;
    }
}
