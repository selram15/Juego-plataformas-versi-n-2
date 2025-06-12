using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // El jugador a seguir
    public float smoothSpeed = 0.125f; // Velocidad de suavizado (cuanto m�s bajo, m�s suave)
    public Vector3 offset; // Desplazamiento de la c�mara respecto al jugador

    private Vector3 velocity = Vector3.zero; // Variable interna para SmoothDamp

    void Start()
    {
        // Aseg�rate de que el jugador est� asignado correctamente
        if (player == null)
        {
            Debug.LogError("No se ha asignado el jugador en el script de la c�mara.");
        }
    }

    void LateUpdate()
    {
        // Determina la posici�n deseada de la c�mara, usando el desplazamiento (offset)
        Vector3 targetPosition = player.position + offset;

        // Suaviza el movimiento de la c�mara utilizando SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }
}
