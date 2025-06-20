using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControl : MonoBehaviour
{
    public GameObject camera;
    public Rigidbody2D rgbd2d;
    [SerializeField] float velocity = 5f;
    private Quaternion targetRotation;

    [SerializeField] private Transform groundCheckPoint; // Asignar desde el inspector, por ejemplo un Empty en los pies
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer; // Asigna la capa de suelo desde el Inspector
    private bool isGrounded;

    public Vector3 RespawnPosition;
    private bool lateralGravity=false;
    private float rotationSpeed = 500f;
    private float camerarotationSpeed = 10f;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;
    private bool moving=false;
    private bool fly=false;
    private bool rotatioNeeded = true;
    void Start()
    {
        rgbd2d=GetComponent<Rigidbody2D>();
        playerAnimator=GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Physics2D.gravity = new Vector2(0, -9.81f);

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.gravity = new Vector2(0, -9.81f); 
            lateralGravity =false;
            targetRotation = Quaternion.Euler(0, 0, 0);
            rotatioNeeded = true;

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Physics2D.gravity = new Vector2(0, 9.81f);
            lateralGravity = false;
            targetRotation = Quaternion.Euler(0, 0, 180);
            rotatioNeeded =false;

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Physics2D.gravity = new Vector2(-9.81f, 0);
            lateralGravity = true;
            targetRotation = Quaternion.Euler(0, 0, -90);

            rotatioNeeded = true;

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Physics2D.gravity = new Vector2(9.81f, 0);
            lateralGravity = true;
            targetRotation = Quaternion.Euler(0, 0, 90);

            rotatioNeeded = false;

        }
        if (!fly)
        {

            if (lateralGravity)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    rgbd2d.velocity = new Vector2(rgbd2d.velocity.x, -velocity);
                    if (!fly)
                    {
                        moving = true;
                    }
                    if (rotatioNeeded)
                    {
                        spriteRenderer.flipX = false;
                    }
                    else
                    {
                        spriteRenderer.flipX = true;
                    }
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    rgbd2d.velocity = new Vector2(rgbd2d.velocity.x, velocity);
                    if (!fly)
                    {
                        moving = true;
                    }
                    if (rotatioNeeded)
                    {
                        spriteRenderer.flipX = true;
                    }
                    else
                    {
                        spriteRenderer.flipX = false;
                    }
                }
                else
                {
                    moving = false;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    playerAnimator.SetTrigger("Run");

                    rgbd2d.velocity = new Vector2(-velocity, rgbd2d.velocity.y);
                    if (!fly)
                    {
                        moving = true;
                    }
                    if (rotatioNeeded)
                    {
                        spriteRenderer.flipX = true;
                    }
                    else
                    {
                        spriteRenderer.flipX = false;
                    }
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {

                    rgbd2d.velocity = new Vector2(velocity, rgbd2d.velocity.y);
                    if (!fly)
                    {
                        moving = true;
                    }
                    if (rotatioNeeded)
                    {
                        spriteRenderer.flipX = false;
                    }
                    else
                    {
                        spriteRenderer.flipX = true;
                    }
                }
                else
                {
                    playerAnimator.SetTrigger("Idle");

                    moving = false;
                }
            }
        }
        if (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }
        Vector2 origin = (Vector2)transform.position + Vector2.down * 0.55f; // ajusta si es necesario
        float checkDistance = 0.4f; // aumenta si el personaje flota un poco

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, checkDistance);
        Debug.DrawRay(origin, Vector2.down * checkDistance, hit.collider ? Color.green : Color.red);

        if (hit.collider != null)
        {
            fly = false;
            Debug.Log("Tocando algo: " + hit.collider.name);
        }
        else
        {
            fly = true;
            Debug.Log("NO tocando nada");
        }
        if (moving)
        {
            playerAnimator.SetTrigger("Run");
        }
        else if (!moving && !fly)
        {
            playerAnimator.SetTrigger("Idle");
        }
        else if (fly)
        {
            playerAnimator.SetTrigger("Air");
        }

    }

    public void ResetCharacter(Vector3 respawnPosition)
    {
        transform.position = respawnPosition;
        rgbd2d.velocity = Vector2.zero;
        Physics2D.gravity = new Vector2(0, -9.81f);
        targetRotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = targetRotation;
        lateralGravity = false;
        rotatioNeeded = true;
    }

}
