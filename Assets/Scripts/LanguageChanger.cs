using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageChanger : MonoBehaviour
{
    static string language = "English";
    public GameObject[] EnglishTexts;
    public GameObject[] RussianTexts;
    public GameObject[] PortugueseTexts;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(language == "English")
        {
            for (int i = 0; i < EnglishTexts.Length; i++)
            {
                EnglishTexts[i].SetActive(true);
                RussianTexts[i].SetActive(false);
                PortugueseTexts[i].SetActive(false);
            }
        }
        if(language == "Russian")
        {
            for (int i = 0; i < RussianTexts.Length; i++)
            {
                RussianTexts[i].SetActive(true);
                EnglishTexts[i].SetActive(false);
                PortugueseTexts[i].SetActive(false);
            }
        }
        if(language == "Portuguese")
        {
            for (int i = 0; i < PortugueseTexts.Length; i++)
            {
                PortugueseTexts[i].SetActive(true);
                EnglishTexts[i].SetActive(false);
                RussianTexts[i].SetActive(false);
            }
        }
    }
    public void ChangeLanguage()
    {
        if (language == "English")
        {
            language = "Russian";
        }
        else if (language == "Russian")
        {
            language = "Portuguese";
        }
        else
        {
            language = "English";
        }
    }
}
