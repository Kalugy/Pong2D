
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Vector2 direction;

    private List<Transform> segments = new List<Transform>();

    public Transform objectSegment;

    public int initialSize;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction =  Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
        

    }

    private void FixedUpdate()
    {

        for(int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
;        }


        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);

    }


    public void Grow()
    {
        Transform newTail = Instantiate(objectSegment);
        newTail.position = segments[segments.Count - 1].position;


        segments.Add(newTail);

    }

    private void ResetState()
    {
        for(int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        for (int i = 1; i < initialSize; i++)
        {
            segments.Add(Instantiate(objectSegment));
        }

        this.transform.position = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Food")
        {
            Grow();
        }
        else if (collision.tag == "Obstacle")
        {
            ResetState();
        }
    }






}
