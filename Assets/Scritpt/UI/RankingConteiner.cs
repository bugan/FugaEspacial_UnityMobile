using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingConteiner : MonoBehaviour
{

    private const int PRIMEIRO_COLOCADO = 1;

    [SerializeField]
    private Ranking ranking;
    [SerializeField]
    private GameObject ItemRankPrefab;
    [SerializeField]
    private int quantidadeParaMostrar;

    private ItemRanking novaPontuacao;

    private void Start()
    {
        this.AdicionarItensSalvos();
    }

    private void AdicionarItensSalvos()
    {
        var item = this.ranking.GetColocado();
        var colocacao = PRIMEIRO_COLOCADO;
        while (ItemExite(item) && this.DevoMostar(colocacao))
        {
            this.InstanciarElementoInterface(item, colocacao);
            colocacao++;
            item = this.ranking.ListaColocados.GetColocado();
        }
    }

    private void InstanciarElementoInterface(Item item, int colocacao)
    {
        var itemInterface = GameObject.Instantiate(this.ItemRankPrefab, this.transform);
        itemInterface.GetComponent<ItemRanking>().Configurar(colocacao + "°", item.nome, item.pontos);
    }

    private bool DevoMostar(int colocacao)
    {
        return colocacao <= this.quantidadeParaMostrar;
    }

    private static bool ItemExite(Item item)
    {
        return item != null;
    }
}