using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arco : MonoBehaviour
{
    public IEnumerator arcoTrajetoria(Vector3 destino, float duracao)
    {
        var posicaoInicial = transform.position;
        var percenturalCompleto = 0.0f;
        while (percenturalCompleto < 1.0f)
        {
            percenturalCompleto += Time.deltaTime / duracao;
            var alturaCorrente = Mathf.Sin(Mathf.PI * percenturalCompleto);
            transform.position = Vector3.Lerp(posicaoInicial, destino, percenturalCompleto) + Vector3.up*alturaCorrente;
            percenturalCompleto += Time.deltaTime / duracao;
            yield return null;
        }
        gameObject.SetActive(false);
    }
    
}
