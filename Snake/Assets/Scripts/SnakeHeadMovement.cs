using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHeadMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed, turnSpeed;
    [SerializeField] Rigidbody2D rb;

    float direction = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += moveSpeed * Time.deltaTime * transform.up;
        //direction = Input.GetAxisRaw("Horizontal");
        //if(direction != 0)
        //    transform.Rotate(0, 0, turnSpeed * Time.deltaTime * direction);
        direction = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rb.velocity = moveSpeed * Time.fixedDeltaTime * transform.up;
        if (direction != 0)
            rb.rotation += turnSpeed * direction;
    }
}
