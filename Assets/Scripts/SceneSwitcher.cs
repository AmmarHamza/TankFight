using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadGame()
    {
        StartCoroutine(LoadGameCoroutine());
    }
    public void LoadSettings()
    {
        StartCoroutine(LoadSettingsCoroutine());
    }
    public void LoadShop()
    {
        StartCoroutine(LoadShopCoroutine());
    }

    IEnumerator LoadGameCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainGame");
    }
    IEnumerator LoadSettingsCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Settings");
    }
    IEnumerator LoadShopCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Shop");
    }
}
