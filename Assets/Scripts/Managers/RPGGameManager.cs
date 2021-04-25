using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPGGameManager : MonoBehaviour
{
    private static int fase = 1;
    public static RPGGameManager instanciaCompartilhada = null;
    public RPGCameraManager cameraManager;
    public PontoSpawn playerPontoSpawn;
    private void Awake()
    {
        if (instanciaCompartilhada != null && instanciaCompartilhada != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instanciaCompartilhada = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupScene();
    }

    public void SetupScene()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (playerPontoSpawn != null)
        {
            GameObject player = playerPontoSpawn.Spawn0();
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public static void GerenciadorDeCena()
    {
        switch (fase)
        {
            case 1:
                fase = 2;
                SceneManager.LoadScene("Fase12");
                break;
            case 2:
                fase = 3;
                SceneManager.LoadScene("Fase23");
                break;
            case 3:
                fase = 1;
                SceneManager.LoadScene("MissaoCumprida");
                break;
            default:
                fase = 1;
                SceneManager.LoadScene("Lab5");
                break;
        }
    }
}
