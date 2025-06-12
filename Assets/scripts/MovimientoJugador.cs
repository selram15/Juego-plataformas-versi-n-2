using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // <-- Solo si quieres reiniciar la escena cuando pierda todas las vidas

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;
    public Transform sensorSuelo;
    public LayerMask capaSuelo;
    public Transform puntoRespawn;

    public int vidas = 3;

    private Rigidbody2D rb;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (puntoRespawn == null)
        {
            Debug.LogWarning("No se ha asignado el punto de respawn.");
        }
    }

    void Update()
    {
        float mover = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(mover * velocidad, rb.velocity.y);

        // Puedes ajustar el radio si es demasiado pequeño para tu personaje
        enSuelo = Physics2D.OverlapCircle(sensorSuelo.position, 0.2f, capaSuelo);

        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("ZonaMuerte"))
        {
            TomarDaño();
        }
    }

    public void TomarDaño()
    {
        vidas--;

        if (vidas > 0)
        {
            StartCoroutine(Reaparecer());
        }
        else
        {
            vidas = 3; // Reinicia las vidas si quieres reiniciar desde 0
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private System.Collections.IEnumerator Reaparecer()
    {
        rb.velocity = Vector2.zero;
        rb.simulated = false; // Desactiva física para evitar efectos raros
        yield return new WaitForSeconds(0.5f); // Pequeña pausa antes de reaparecer

        if (puntoRespawn != null)
        {
            transform.position = puntoRespawn.position;
        }

        rb.simulated = true;
    }
}
