using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 respawnPos;         // Guarda la posici�n del checkpoint
    public Dead point;                  // Referencia a un script que maneja el respawn
    public CharacterControl characterControl; // Referencia al script del jugador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Detecta al jugador
        {
            respawnPos = transform.position + new Vector3(0f, 0.5f, 0f); // Offset de +0.5 en Y
            characterControl.RespawnPosition = respawnPos;     // Se la pasa al sistema de respawn
        }
    }
}
