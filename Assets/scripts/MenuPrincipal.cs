using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Game scene");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("El juego se cerraría aquí (funciona al compilar).");
    }
}
