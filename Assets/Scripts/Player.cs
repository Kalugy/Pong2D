using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float boundaryY = 5.0f;
    public float speed = 1;
    public string inputName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float up = Input.GetAxis(inputName);
        Debug.Log(transform.position);
        
        if (transform.position.y <= boundaryY && transform.position.y >= -boundaryY)
        {
            
            transform.position = new Vector3(transform.position.x, (up / 8) + transform.position.y, transform.position.z) * speed;
        }
        if (transform.position.y > boundaryY)
        {
            transform.position = new Vector3(transform.position.x, boundaryY, transform.position.z);
        }
        if (transform.position.y < -boundaryY)
        {
            transform.position = new Vector3(transform.position.x, -boundaryY, transform.position.z);
        }
    }
}
