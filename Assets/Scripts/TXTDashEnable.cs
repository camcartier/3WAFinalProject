using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TXTDashEnable : MonoBehaviour
{
    private GameObject DashPanel;

    // Start is called before the first frame update
    void Start()
    {
        DashPanel = GameObject.Find("DashPanel");
    }

    public void TXTEnable()
    {
        DashPanel.SetActive(true);
    }
}
