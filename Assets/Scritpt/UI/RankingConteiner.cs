using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingConteiner : MonoBehaviour
{

    [SerializeField]
    private Ranking ranking;
    [SerializeField]
    private GameObject ItemRankPrefab;

    private void Start()
    {
        this.AdicionarItensSalvos();
    }

    private void AdicionarItensSalvos()
    {
        var item = this.ranking.GetColocado();

        var colocacao = 1;
        while (item != null)
        {
            this.InstanciarElementoInterface(item, colocacao);
            colocacao++;
            item = this.ranking.GetColocado();
        }
    }

    private void InstanciarElementoInterface(Item item, int colocacao)
    {
        var itemInterface = GameObject.Instantiate(this.ItemRankPrefab, this.transform);
        itemInterface.GetComponent<ItemRanking>().Configurar(colocacao + "°", item.nome, item.pontos);
    }
}
