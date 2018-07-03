using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfiguracaoVibrar : MonoBehaviour
{
    [SerializeField]
    private Toggle toggle;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Vibrar") == 1)
        {
            this.toggle.isOn = true;
        }
        else
        {
            this.toggle.isOn = false;
        }
    }

    public void SalvarConfiguracao(bool vibrar)
    {
        if (vibrar)
        {
            PlayerPrefs.SetInt("Vibrar", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Vibrar", 0);
        }
    }
}
