using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Vector2 puntoA, puntoB;
    public float velocidad = 2f;
    bool haciaB = true;

    void Update()
    {
        // Elige el destino según la dirección actual
        Vector2 destino = haciaB ? puntoB : puntoA;

        // Mueve la plataforma hacia el destino
        transform.position = Vector2.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        // Cambia la dirección cuando llega al destino
        if (Vector2.Distance(transform.position, destino) < 0.1f)
            haciaB = !haciaB;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Si el jugador toca la plataforma, lo hace hijo de la plataforma
        if (col.gameObject.CompareTag("Player"))
            col.transform.SetParent(transform);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        // Cuando el jugador sale de la plataforma, lo desvincula
        if (col.gameObject.CompareTag("Player"))
            col.transform.SetParent(null);
    }
}
