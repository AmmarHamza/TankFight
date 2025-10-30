using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public void HomeButton()
    {
        StartCoroutine(HomeButtonCoroutine());
    }
    IEnumerator HomeButtonCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
