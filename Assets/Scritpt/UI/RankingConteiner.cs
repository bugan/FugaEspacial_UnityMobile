using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingConteiner : MonoBehaviour
{
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
        var colocacao = 1;
        while (item != null && colocacao <= this.quantidadeParaMostrar)
        {
            var gobj = GameObject.Instantiate(this.ItemRankPrefab, this.transform);
            gobj.GetComponent<ItemRanking>().Configurar(colocacao + "°", item.nome, item.pontos);

            colocacao++;
            item = this.ranking.ListaColocados.GetColocado();
        }
    }
}