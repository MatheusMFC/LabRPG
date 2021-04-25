using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Cena12()
    {
        SceneManager.LoadScene("Fase2");
    }

    public void Cena23()
    {
        SceneManager.LoadScene("Fase3");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Lab5");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void EndGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
