using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // El jugador a seguir
    public float smoothSpeed = 0.125f; // Velocidad de suavizado (cuanto más bajo, más suave)
    public Vector3 offset; // Desplazamiento de la cámara respecto al jugador

    private Vector3 velocity = Vector3.zero; // Variable interna para SmoothDamp

    void Start()
    {
        // Asegúrate de que el jugador esté asignado correctamente
        if (player == null)
        {
            Debug.LogError("No se ha asignado el jugador en el script de la cámara.");
        }
    }

    void LateUpdate()
    {
        // Determina la posición deseada de la cámara, usando el desplazamiento (offset)
        Vector3 targetPosition = player.position + offset;

        // Suaviza el movimiento de la cámara utilizando SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }
}
