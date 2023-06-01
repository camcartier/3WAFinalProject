using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerWCredits : MonoBehaviour
{
    [SerializeField] GameObject PanelMusicCredits;
    [SerializeField] GameObject SpecialThanks01;
    [SerializeField] GameObject SpecialThanks02;

    [SerializeField] GameObject QuitButton;
    [SerializeField] GameObject SpecialThanksTXT;
    [SerializeField] GameObject ThanksTitle;

    [SerializeField] GameObject smileyFace;

    void Start()
    {
        StartCoroutine(HandleScreenTime());
    }

    private IEnumerator HandleScreenTime()
    {
        yield return new WaitForSeconds(4f);
        PanelMusicCredits.SetActive(true);
        yield return new WaitForSeconds(5.25f);
        PanelMusicCredits.SetActive(false);
        SpecialThanksTXT.SetActive(true);
        SpecialThanks01.SetActive(true);
        yield return new WaitForSeconds(3f);
        SpecialThanks01.SetActive(false);
        SpecialThanks02.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        SpecialThanks02.SetActive(false);
        SpecialThanksTXT.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        smileyFace.SetActive(true);

    }
}
