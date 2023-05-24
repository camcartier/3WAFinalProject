using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameChooser : MonoBehaviour
{
    public string nameOfPlayer;
    public string savedName;

    public TextMeshProUGUI inputText;
    public TextMeshProUGUI loadedName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName()
    {
        savedName= inputText.text;

    }
}
