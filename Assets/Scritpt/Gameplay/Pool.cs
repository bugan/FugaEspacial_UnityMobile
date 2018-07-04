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
    private bool permitirCrescimento;

    private Stack<ObjetoDePool> lista;

    private void Awake()
    {
        this.lista = new Stack<ObjetoDePool>();

        this.PreencherPool();
    }

    private void PreencherPool()
    {
        for (var i = 0; i < this.quantidadeInicial; i++)
        {
            this.CriarNovaInstancia();
        }
    }

    private void CriarNovaInstancia()
    {
        GameObject instancia = this.CriarInstanciaDoPrefab();
        ObjetoDePool objetoParaPool = this.IniciarComponenteObjetoDePool(instancia);
        objetoParaPool.DevolverParaPool();
    }

    public ObjetoDePool PegarObjeto()
    {
        if (this.PoolEstaVazia())
        {
            if (this.permitirCrescimento)
            {
                this.CriarNovaInstancia();
                return this.RetirarObjetoDaPool();
            }
        }
        else
        {
            return this.RetirarObjetoDaPool();
        }

        return null;
    }

    private ObjetoDePool RetirarObjetoDaPool()
    {
        var objeto = this.lista.Pop();
        objeto.AoSairDaPool();
        return objeto;
    }

    public void DevolverObjeto(ObjetoDePool objeto)
    {
        objeto.AoEntrarNaPool();
        this.lista.Push(objeto);
    }

    private bool PoolEstaVazia()
    {
        return this.lista.Count <= 0;
    }

    private ObjetoDePool IniciarComponenteObjetoDePool(GameObject instancia)
    {
        var objetoParaPool = instancia.GetComponent<ObjetoDePool>();
        objetoParaPool.Iniciar(this);
        return objetoParaPool;
    }

    private GameObject CriarInstanciaDoPrefab()
    {
        var instancia = GameObject.Instantiate(prefab.gameObject);
        instancia.SetActive(false);
        return instancia;
    }

}
