using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public GameObject slotPrefab;       //Objeto que recebe o prefab Slot
    public const int numSlots = 5;      //Número fixo de Slots
    Image[] itemImagens = new Image[numSlots]; //Array de imagens
    Item[] itens = new Item[numSlots]; //Array de itens
    GameObject[] slots = new GameObject[numSlots]; //Array de Slots

    // Start is called before the first frame update
    void Start()
    {
        CriaSlots();
    }


    public void CriaSlots()
    {
        if(slotPrefab != null)
        {
            for (int i = 0; i<numSlots; i++)
            {
                GameObject novoSlot = Instantiate(slotPrefab);
                novoSlot.name = "ItemSlot_" + i;
                novoSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                slots[i] = novoSlot;
                itemImagens[i] = novoSlot.transform.GetChild(1).GetComponent<Image>();
            }
        }
    }

    public bool AddItem(Item itemToAdd)
    {
        for (int i =0; i<itens.Length; i++)
        {
            if (itens[i] != null && itens[i].tipoItem == itemToAdd.tipoItem && itemToAdd.empilhavel == true)
            {
                itens[i].quantidade = itens[i].quantidade + 1;
                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
                Text quantidadeTexto = slotScript.qtdeTexto;
                quantidadeTexto.enabled = true;
                quantidadeTexto.text = itens[i].quantidade.ToString();
                return true;
            }
            if (itens[i] == null)
            {
                itens[i] = Instantiate(itemToAdd);
                itens[i].quantidade = 1;
                itemImagens[i].sprite = itemToAdd.sprite;
                itemImagens[i].enabled = true;
                return true;
            }
        }
        return false;
    }
}
