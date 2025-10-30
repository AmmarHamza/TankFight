using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq;

public class Shop : MonoBehaviour
{
    public GameObject[] tanks;
    public int price = 100;
    public static List<bool> isBought = new List<bool>() {true, false, false, false, false};
    public static int selectedTank = 0;
    public TextMeshProUGUI priceText;
    public GameObject BuyButton;
    public GameObject SelectButton;

    // Start is called before the first frame update
    void Start()
    {
        LoadIsBought();
        tanks[0].SetActive(true);
        priceText.text = price.ToString();
        BuyButton.SetActive(false);
        SelectButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyTank()
    {
        for (int i = 0; i < tanks.Length; i++)
        {
            if (tanks[i].activeInHierarchy && Score.score >= price)
            {
                Score.score -= price;
                isBought[i] = true;
                CheckIfBought(i);
                SaveIsBought();
                break;
            }
        }
    }
    public void SelectTank()
    {
        for (int i = 0; i < tanks.Length; i++)
        {
            if (tanks[i].activeInHierarchy)
            {
                selectedTank = i;
                break;
            }
        }
    }
    public void SwitchTank(int j)
    {
        for (int i = 0; i < tanks.Length; i++)
        {
            if (tanks[i].activeInHierarchy)
            {
                if (j > 0)
                {
                    tanks[i].SetActive(false);
                    if(i == tanks.Length - 1)
                    {
                        tanks[0].SetActive(true);
                        CheckIfBought(0);
                    }
                    else
                    {
                        tanks[i + 1].SetActive(true);
                        CheckIfBought(i+1);
                    }
                }
                else
                {
                    tanks[i].SetActive(false);
                    if (i == 0)
                    {
                        tanks[tanks.Length - 1].SetActive(true);
                        CheckIfBought(tanks.Length - 1);
                    }
                    else
                    {
                        tanks[i - 1].SetActive(true);
                        CheckIfBought(i - 1);
                    }
                }
                break;
            }
        }
    }
    void CheckIfBought(int i)
    {
        if (isBought[i])
        {
            BuyButton.SetActive(false);
            SelectButton.SetActive(true);
        }
        else
        {
            BuyButton.SetActive(true);
            SelectButton.SetActive(false);
        }
    }
    public static void SaveIsBought()
    {
        Bought bought = new Bought(isBought);
        string json = JsonUtility.ToJson(bought);
        File.WriteAllText(Application.dataPath + "/isBought.json", json);
    }

    public static void LoadIsBought()
    {
        if (File.Exists(Application.dataPath + "/isBought.json"))
        {
            string json = File.ReadAllText(Application.dataPath + "/isBought.json");
            Bought bought = JsonUtility.FromJson<Bought>(json);
            isBought = bought.isBought.ToList();
        }
        else
        {
            SaveIsBought();
        }
    }
}

[System.Serializable]
public class Bought
{
    public bool[] isBought = new bool[5];
    //Declare a constructor to initialize the characters array from a list of characters
    public Bought(List<bool> isBought)
    {
        this.isBought = isBought.ToArray();
    }
}