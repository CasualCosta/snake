using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    Rigidbody2D snakeHeadRB;
    [HideInInspector] public SnakeManager snakeManager;
    [SerializeField] float moveSpeed = 280;
    [SerializeField] float turnSpeed = 180;
    [SerializeField] float turningSpeedMultiplier = 1.5f;

    float direction;
    bool playing = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if(playing)
            Move();
    }

    void Move()
    {
        if (snakeHeadRB == null)
            snakeHeadRB = snakeManager.snakeBody[0].GetComponent<Rigidbody2D>();
        snakeHeadRB.velocity = moveSpeed * (direction == 0 ? 1f : turningSpeedMultiplier) * Time.deltaTime * snakeManager.snakeBody[0].transform.up;
        if (direction != 0)
            snakeManager.snakeBody[0].transform.Rotate(new Vector3(0, 0, -turnSpeed * Time.fixedDeltaTime * direction));

        if (snakeManager.snakeBody.Count > 1)
        {
            for (int i = 1; i < snakeManager.snakeBody.Count; i++)
            {
                MarkerManager markerManager = snakeManager.snakeBody[i - 1].GetComponent<MarkerManager>();
                snakeManager.snakeBody[i].transform.position = markerManager.markers[0].position;
                snakeManager.snakeBody[i].transform.rotation = markerManager.markers[0].rotation;
                markerManager.markers.RemoveAt(0);
            }
        }
    }

    public void Stop()
    {
        playing = false;
        snakeHeadRB.velocity = Vector2.zero;
    }
}
