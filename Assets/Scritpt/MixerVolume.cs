using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerVolume : MonoBehaviour {

    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private string parametro;

    public void MudarVolume(float valorSlider)
    {
        var volume = Mathf.Lerp(-60, 10, valorSlider);
        this.mixer.SetFloat(parametro, volume);
        
    }
}
