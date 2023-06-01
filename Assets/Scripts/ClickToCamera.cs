using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToCamera : MonoBehaviour
{
    [SerializeField] Camera Camera1;
    [SerializeField] Camera Camera2;
    [SerializeField] ButtonClicked ButtonClicked;

    //Camera[] cameraList;

    private int clicked;

    // Start is called before the first frame update
    void Start()
    {
        //cameraList = new Camera[] { Camera1, Camera2 };
    }

    // Update is called once per frame
    void Update()
    {
        clicked = ButtonClicked.clickNumber;

        if (clicked == 0 || clicked == 1)
        {
            Camera1.enabled = true;
            Camera2.enabled = false;
        }
        if (clicked == 2 || clicked == 3 || clicked == 4)
        {
            Camera1.enabled = false;
            Camera2.enabled = true;
        }
    }
}
