using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TXTErase : MonoBehaviour
{
    private GameObject DashPanel;

    void Awake()
    {
        DashPanel = GameObject.Find("DashPanel");
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Erase());
    }

    private IEnumerator Erase()
    {
        yield return new WaitForSeconds(3f);
        DashPanel.SetActive(false);
    }
}
