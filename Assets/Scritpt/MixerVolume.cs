using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerVolume : MonoBehaviour {
    private const float VOLUME_MINIMO = -80;
    private const float VOLUME_MAXIMO = 10;

    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private string parametro;

    public void MudarVolume(float valorSlider)
    {
        var volume = Mathf.Lerp(VOLUME_MINIMO, VOLUME_MAXIMO, valorSlider);
        this.mixer.SetFloat(parametro, volume);
        
    }
}
