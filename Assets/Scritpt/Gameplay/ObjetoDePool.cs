using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDePool : MonoBehaviour {    
    private Pool minhaPool;

	public void Iniciar(Pool minhaPool)
    {
        this.minhaPool = minhaPool;
    }

    public void DevolverParaPool()
    {
        this.minhaPool.DevolverObjeto(this);
    }

    public  void AoEntrarNaPool()
    {
        this.gameObject.SetActive(false);
    }

    public void AoSairDaPool()
    {
        this.gameObject.SetActive(true);
    }
}
