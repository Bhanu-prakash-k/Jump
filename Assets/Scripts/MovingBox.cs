using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    public float moveSpeed = 1f;
    bool moveRight = true;
    public float movementPoint = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > movementPoint)
            moveRight = false;
        if(transform.position.x < -movementPoint)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector3(transform.position.x + moveSpeed, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x - moveSpeed, transform.position.y, transform.position.z);
    }
}
