using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCtrlsTXT : MonoBehaviour
{
    [SerializeField] GameObject CTRLSPanel;

    public void Enable()
    {
        CTRLSPanel.SetActive(true);
    }

}
