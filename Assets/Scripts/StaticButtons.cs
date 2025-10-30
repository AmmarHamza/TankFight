using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticButtons : MonoBehaviour
{
    public GameObject SoundOn;
    public GameObject SoundOff;
    public GameObject MusicOn;
    public GameObject MusicOff;


    static bool SoundOnActive = true;
    static bool SoundOffActive = false;
    static bool MusicOnActive = true;
    static bool MusicOffActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SoundOnActive)
        {
            SoundOn.SetActive(true);
        }
        else
        {
            SoundOn.SetActive(false);
        }
        if (SoundOffActive)
        {
            SoundOff.SetActive(true);
        }
        else
        {
            SoundOff.SetActive(false);
        }
        if (MusicOnActive)
        {
            MusicOn.SetActive(true);
        }
        else
        {
            MusicOn.SetActive(false);
        }
        if (MusicOffActive)
        {
            MusicOff.SetActive(true);
        }
        else
        {
            MusicOff.SetActive(false);
        }
    }
    public void SwitchSound()
    {
        SoundOnActive = !SoundOnActive;
        SoundOffActive = !SoundOffActive;
    }
    public void SwitchMusic()
    {
        MusicOnActive = !MusicOnActive;
        MusicOffActive = !MusicOffActive;
    }
}
