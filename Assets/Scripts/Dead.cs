using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Dead : MonoBehaviour
{
    public Vector3 RespawnPosition;
    public GameObject player;
    public Gestordevidas gestordevidas;

    private void Start()
    {
        RespawnPosition = transform.position + new Vector3(0f, 0.5f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<CharacterControl>().ResetCharacter(RespawnPosition);
            gestordevidas.vidas--;
        }
    }
}
