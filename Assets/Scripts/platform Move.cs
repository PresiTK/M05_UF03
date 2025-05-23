using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{

    public List<Transform> points;
    public int nextPoint = 0;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = points[nextPoint].position - transform.position;
        float distance = dir.magnitude;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        if (distance < 0.1f)
        {
            nextPoint++;
            if (nextPoint >= points.Count)
            {
                nextPoint = 0;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(gameObject.transform);
        }
    }
}
