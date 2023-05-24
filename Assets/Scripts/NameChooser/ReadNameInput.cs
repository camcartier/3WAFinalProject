using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNameInput : MonoBehaviour
{
    [SerializeField] PlayerData PlayerData;

    private string input;

    public void ReadStringInput(string name)
    {
        input = name;
        Debug.Log(input);
        PlayerData._name = input;
    }
}
