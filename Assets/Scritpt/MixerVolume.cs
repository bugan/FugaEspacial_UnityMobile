using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerVolume : MonoBehaviour {

    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private string parametro;

    public void MudarAudio(float config)
    {
        var volume = Mathf.Lerp(-60, 0, config);
        this.mixer.SetFloat(parametro, volume);
    }
}
