using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 respawnPos;         // Guarda la posición del checkpoint
    public Dead point;                  // Referencia a un script que maneja el respawn

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Detecta al jugador
        {
            respawnPos = transform.position + new Vector3(0f, 0.5f, 0f); // Offset de +0.5 en Y
            point.RespawnPosition = respawnPos;     // Se la pasa al sistema de respawn
        }
    }
}
