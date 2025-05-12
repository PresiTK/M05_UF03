using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rgbd2d;
    [SerializeField] float velocity = 5f;
    private bool lateralGravity=false;
    void Start()
    {
        rgbd2d=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.gravity = new Vector2(0, -9.81f); 
            lateralGravity =false;
            transform.rotation = Quaternion.Euler(0, 0, 0);  // Rotación de 90 grados sobre el eje Z
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Physics2D.gravity = new Vector2(0, 9.81f);
            lateralGravity = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);  // Rotación de 90 grados sobre el eje Z

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Physics2D.gravity = new Vector2(-9.81f, 0);
            lateralGravity = true;
            transform.rotation = Quaternion.Euler(0, 0, 90);  // Rotación de 90 grados sobre el eje Z

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Physics2D.gravity = new Vector2(9.81f, 0);
            lateralGravity = true;
            transform.rotation = Quaternion.Euler(0, 0, 90);  // Rotación de 90 grados sobre el eje Z

        }
        if (lateralGravity)
        {
            // Movimiento cuando lateralGravity es verdadero (vertical)
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rgbd2d.velocity = new Vector2(rgbd2d.velocity.x, -velocity); // Movimiento hacia abajo
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                rgbd2d.velocity = new Vector2(rgbd2d.velocity.x, velocity); // Movimiento hacia arriba
            }
        }
        else
        {
            // Movimiento cuando lateralGravity es falso (horizontal)
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rgbd2d.velocity = new Vector2(-velocity, rgbd2d.velocity.y); // Movimiento hacia la izquierda
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rgbd2d.velocity = new Vector2(velocity, rgbd2d.velocity.y); // Movimiento hacia la derecha
            }
        }

    }
}
