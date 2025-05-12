using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rgbd2d;
    [SerializeField] float velocity = 5f;
    private Quaternion targetRotation;
    private bool lateralGravity=false;
    private float rotationSpeed = 500f;
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
            targetRotation = Quaternion.Euler(0, 0, 0);  

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Physics2D.gravity = new Vector2(0, 9.81f);
            lateralGravity = false;
            targetRotation = Quaternion.Euler(0, 0, 180);  


        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Physics2D.gravity = new Vector2(-9.81f, 0);
            lateralGravity = true;
            targetRotation = Quaternion.Euler(0, 0, -90);  


        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Physics2D.gravity = new Vector2(9.81f, 0);
            lateralGravity = true;
            targetRotation = Quaternion.Euler(0, 0, 90);  


        }
        if (lateralGravity)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rgbd2d.velocity = new Vector2(rgbd2d.velocity.x, -velocity); 
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                rgbd2d.velocity = new Vector2(rgbd2d.velocity.x, velocity); 
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rgbd2d.velocity = new Vector2(-velocity, rgbd2d.velocity.y); 
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rgbd2d.velocity = new Vector2(velocity, rgbd2d.velocity.y); 
            }
        }
        if (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
