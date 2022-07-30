using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Camera Camera;
    public LayerMask layerMask;

    public int touchCount;
    public int curCount;

    public float speed;
    
    Vector3 MousePosition;

    void Start()
    {
        Camera = FindObjectOfType<Camera>();
        touchCount = Random.Range(7, 10);
    }

    void Update()
    {
        Move();
        Touch();

        if(curCount >= touchCount)
        {
            Destroy(gameObject);
            curCount = 0;
        }
    }

    void Touch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);
            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.position, 1f, layerMask);

            if (hit)
            {
                curCount++;
            }
        }
    }

    void Move()
    {
        transform.Translate(Vector2.left * speed);

        if(transform.position.x < -3.2f)
        {
            Destroy(gameObject);
        }
    }
}
