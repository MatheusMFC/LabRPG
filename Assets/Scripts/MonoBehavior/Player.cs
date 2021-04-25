using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Caractere
{
    public Inventario inventarioPrefab;         //referência ao objeto prefab criado no Inventário
    Inventario inventario;
    public HealthBar healthBarPrefab;           //referência ao objeto prefab da HealthBar
    HealthBar healthBar;

    public PontosDano pontosDano;  //Tem o valor do objeto script

    private void Start()
    {
        inventario = Instantiate(inventarioPrefab);
        pontosDano.valor = inicioPontosDano;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
    }

    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickCaractere());
            pontosDano.valor = pontosDano.valor - dano;
            if (pontosDano.valor <= float.Epsilon)
            {
                KillCaractere();
                break;
            }
            if (intervalo > float.Epsilon)
            {
                yield return new WaitForSeconds(intervalo);
            }
            else
            {
                break;
            }
        }
    }

    public override void ResetCaractere()
    {
        inventario = Instantiate(inventarioPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
        pontosDano.valor = inicioPontosDano;
    }

    public override void KillCaractere()
    {
        base.KillCaractere();
        Destroy(healthBar.gameObject);
        Destroy(inventario.gameObject);
        SceneManager.LoadScene("GameOver");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coletavel"))
        {
            Item DanoObjeto = collision.gameObject.GetComponent<Consumable>().item;
            if (DanoObjeto != null)
            {
                bool DeveDesaparecer = false;
                //print("Acertou: " + DanoObjeto.NomeObjeto);
                switch (DanoObjeto.tipoItem)
                {
                    case Item.TipoItem.MOEDA:
                        //DeveDesaparecer = true;
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;

                    case Item.TipoItem.POCAO1:
                        //DeveDesaparecer = true;
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;

                    case Item.TipoItem.POCAO2:
                        //DeveDesaparecer = true;
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;

                    case Item.TipoItem.POKEBOLA:
                        //DeveDesaparecer = true;
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;

                    case Item.TipoItem.VELA:
                        //DeveDesaparecer = true;
                        DeveDesaparecer = inventario.AddItem(DanoObjeto);
                        break;

                    case Item.TipoItem.HEALTH:
                        DeveDesaparecer = AjustePontosDano(DanoObjeto.quantidade);
                        break;
                    default:
                        break;

                }
                if (DeveDesaparecer)
                {
                    collision.gameObject.SetActive(false);
                }
                
            }
          
        }
    }

    public bool AjustePontosDano(int quantidade)
    {
        if (pontosDano.valor < MaxPontosDano)
        {
            pontosDano.valor = pontosDano.valor + quantidade;
            print("Ajustando Pontos Dano por: " + quantidade + ". Novo Valor = " + pontosDano.valor);
            return true;
        }
        else return false;
    }
}


