using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PontosDano pontosDano;       //Objeto de leitura dos dados de quantos pontos tem o Player
    public Player caractere;            //Receberá o objeto do Player
    public Image medidorImagem;         //Recebe a barra de medição
    public Text pdTexto;                //Recebe os dados de PD
    float maxPontosDano;                //Armazena a quantidade limite de "vida" do  Player
    

    // Start is called before the first frame update
    void Start()
    {
        maxPontosDano = caractere.MaxPontosDano;
    }

    // Update is called once per frame
    void Update()
    {
        if (caractere != null)
        {
            medidorImagem.fillAmount = pontosDano.valor/maxPontosDano;
            pdTexto.text = "PD:" + (medidorImagem.fillAmount * 100);
        }
    }
}
