using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField]
    private ObjetoDePool prefab;
    [SerializeField]
    private int quantidadeInicial;
    [SerializeField]
    private Stack<ObjetoDePool> lista;
    [SerializeField]
    private bool permitirCrescimento;

    private void Awake()
    {
        this.lista = new Stack<ObjetoDePool>();

        for (var i = 0; i < this.quantidadeInicial; i++)
        {
            this.CriarNovaInstancia();
        }
    }

    private void CriarNovaInstancia()
    {
        var instancia = GameObject.Instantiate(prefab.gameObject);
        instancia.SetActive(false);
        var objetoParaPool = instancia.GetComponent<ObjetoDePool>();
        objetoParaPool.Iniciar(this);
        objetoParaPool.DevolverParaPool();
        
    }

    public ObjetoDePool PegarObjeto()
    {
        if (this.lista.Count <= 0)
        {
            if (this.permitirCrescimento)
            {
                this.CriarNovaInstancia();
                var objeto = this.lista.Pop();
                objeto.AoSairDaPool();
                return objeto;
            }
        }
        else
        {
            var objeto = this.lista.Pop();
            objeto.AoSairDaPool();
            return objeto;
        }

        return null;
    }

    public void DevolverObjeto(ObjetoDePool objeto)
    {
        objeto.AoEntrarNaPool();
        this.lista.Push(objeto);
    }

}
