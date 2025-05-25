using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unblock : MonoBehaviour
{
    public GameObject block;
    public GameObject message;
    private SpriteRenderer unblock;

    private void Start()
    {
        unblock = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            message.SetActive(false);
            block.SetActive(false);
            unblock.enabled = false;
        }
    }

}
