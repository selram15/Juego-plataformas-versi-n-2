using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform puntoA, puntoB;     // Los puntos entre los que el enemigo se mueve
    public float velocidad = 2f;         // Velocidad del movimiento
    private bool haciaB = true;          // Dirección de movimiento, hacia B inicialmente
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Intentar obtener el componente SpriteRenderer para girar el sprite si es necesario
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Define el destino (puntoA o puntoB dependiendo de la dirección)
        Transform destino = haciaB ? puntoB : puntoA;

        // Mueve al enemigo hacia el destino
        transform.position = Vector2.MoveTowards(transform.position, destino.position, velocidad * Time.deltaTime);

        // Verifica si ha llegado al destino
        if (Vector2.Distance(transform.position, destino.position) < 0.1f)
        {
            // Cambia la dirección
            haciaB = !haciaB;

       
        }
    }

    // Detecta las colisiones con el jugador (puedes poner cualquier lógica para dañarlo)
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<MovimientoJugador>().TomarDaño();
        }
    }
}
