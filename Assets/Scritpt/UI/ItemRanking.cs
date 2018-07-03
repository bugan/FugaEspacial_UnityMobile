using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRanking : MonoBehaviour
{

    [SerializeField]
    private Text colocacao;
    [SerializeField]
    private Text nome;
    [SerializeField]
    private Text pontuacao;

    public void Configurar(string colocacao, string nome, int pontuacao)
    {
        this.colocacao.text = colocacao;
        this.nome.text = nome;
        this.pontuacao.text = pontuacao.ToString();
    }

    public void AlterarNome(string nome)
    {
        this.nome.text = nome;
    }
}
