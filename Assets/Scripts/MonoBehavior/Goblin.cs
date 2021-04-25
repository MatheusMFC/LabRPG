using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public GameObject moeda;
    public GameObject pocao1;
    public GameObject pocao2;
    public GameObject vela;
    public GameObject pokebola;
    private bool primeiroToque = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && primeiroToque)
        {
            primeiroToque = false;
            moeda.SetActive(true);
            pocao1.SetActive(true);
            pocao2.SetActive(true);
            pokebola.SetActive(true);
            vela.SetActive(true);
        }
    }
}
