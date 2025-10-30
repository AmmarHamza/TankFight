using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MuteButtons : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MuteMusic()
    {
        audioMixer.SetFloat("musicVol", -80.0f);
    }
    public void UnMuteMusic()
    {
        audioMixer.SetFloat("musicVol", -0);
    }
    public void MuteSFX()
    {
        audioMixer.SetFloat("sfxVol", -80.0f);
    }
    public void UnMuteSFX()
    {
        audioMixer.SetFloat("sfxVol", -0);
    }
}
