using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static GameObject backgroundMusic;
    private void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
