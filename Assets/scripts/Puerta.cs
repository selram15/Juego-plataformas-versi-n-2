using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public bool tieneLlave = false;
    public string nombreEscenaMenu = "MenuPrincipal"; // ? Pon aquí el nombre exacto de tu escena de menú

    void OnTriggerEnter2D(Collider2D col)
    {
        // Si el jugador recoge la llave
        if (col.CompareTag("Llave"))
        {
            tieneLlave = true;
            Destroy(col.gameObject); // Elimina la llave del juego
        }

        // Si el jugador con la llave toca la puerta
        if (col.CompareTag("Player") && tieneLlave)
        {
            StartCoroutine(ReiniciarYVolverAlMenu());
        }
    }

    IEnumerator ReiniciarYVolverAlMenu()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Espera 1 segundo para evitar posibles errores al cargar dos escenas al mismo tiempo
        yield return new WaitForSeconds(1f);

        // Luego va al menú
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}