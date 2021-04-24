using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoSpawn : MonoBehaviour
{
    public GameObject prefabParaSpawn;

    public float intervaloRepeticao;
    
    public void Start()
    {
        if (intervaloRepeticao > 0)
        {
            InvokeRepeating("Spawn0", 0.0f, intervaloRepeticao);
        }
    }

    public GameObject Spawn0()
    {
        if (prefabParaSpawn != null)
        {
            return Instantiate(prefabParaSpawn, transform.position, Quaternion.identity);
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
