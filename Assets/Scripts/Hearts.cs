using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public GameObject[] hearts = new GameObject[3];
    public int numOfHearts = 3;
    
    public void MinusHeart()
    {
        for (int j = 0; j < hearts.Length; j++)
        {
            if (hearts[j].activeInHierarchy)
            {
                hearts[j].SetActive(false);
                numOfHearts--;
                break;
            }
        }
    }
}
