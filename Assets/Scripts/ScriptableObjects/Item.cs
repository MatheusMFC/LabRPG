using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]

public class Item : ScriptableObject
{
    public string NomeObjeto;
    public Sprite sprite;
    public int quantidade;
    public bool empilhavel;

    public enum TipoItem
    {
        MOEDA,
        HEALTH,
        VELA,
        POCAO1,
        POCAO2,
        POKEBOLA
    }

    public TipoItem tipoItem;
}
