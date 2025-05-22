using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float velocidad = 2f;
    public float distancia = 2f;

    private Rigidbody2D rb;
    private Vector2 puntoInicial;
    private int pasoActual = 0;
    private bool regresando = false;
    private float objetivoX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        puntoInicial = transform.position;
        objetivoX = puntoInicial.x + distancia;
    }

    void FixedUpdate()
    {
        float direccion = regresando ? -1f : 1f;
        rb.velocity = new Vector2(direccion * velocidad, 0f);

        if (!regresando && transform.position.x >= puntoInicial.x + (pasoActual + 1) * distancia)
        {
            pasoActual++;
            if (pasoActual >= 4)
            {
                regresando = true;
            }
        }
        else if (regresando && transform.position.x <= puntoInicial.x)
        {
            regresando = false;
            pasoActual = 0;
        }
    }
}
