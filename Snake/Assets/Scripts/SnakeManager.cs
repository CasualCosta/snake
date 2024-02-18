using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    [SerializeField] float spawnInterval = 0.2f;
    [SerializeField] float moveSpeed = 280;
    [SerializeField] float turnSpeed = 18;
    [SerializeField] List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> snakeBody = new List<GameObject>();

    Rigidbody2D snakeHeadRB;
    float direction;
    float countUp = 0;
    // Start is called before the first frame update
    void Start()
    {
        CreateBodyParts();
    }

    private void Update()
    {
        direction = Input.GetAxis("Horizontal");

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (bodyParts.Count > 0)
            CreateBodyParts();
        SnakeMovement();
    }

    void SnakeMovement()
    {
        if (snakeHeadRB == null)
            snakeHeadRB = snakeBody[0].GetComponent<Rigidbody2D>();
        snakeHeadRB.velocity = snakeBody[0].transform.up * moveSpeed * Time.deltaTime;
        if (direction != 0)
            snakeBody[0].transform.Rotate(new Vector3(0, 0, -turnSpeed * Time.fixedDeltaTime * direction));

        if(snakeBody.Count > 1)
        {
            for(int i = 1; i < snakeBody.Count; i++)
            {
                MarkerManager markerManager = snakeBody[i - 1].GetComponent<MarkerManager>();
                print($"Marker manager: {markerManager.gameObject}; Body Part: {snakeBody[i]}.");
                snakeBody[i].transform.position = markerManager.markers[0].position;
                snakeBody[i].transform.rotation = markerManager.markers[0].rotation;
                markerManager.markers.RemoveAt(0);
            }
        }
    }

    void CreateBodyParts()
    {
        if(snakeBody.Count == 0)
        {
            var temp = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);
            if (!temp.GetComponent<MarkerManager>())
                temp.AddComponent<MarkerManager>();
            if (!temp.GetComponent<MarkerManager>())
            {
                temp.AddComponent<Rigidbody2D>();
            }
            snakeBody.Add(temp);
            bodyParts.RemoveAt(0);
        }

        MarkerManager markerManager = snakeBody[snakeBody.Count - 1].GetComponent<MarkerManager>();
        if (countUp == spawnInterval)
            markerManager.ClearMarkers();
        countUp += Time.deltaTime;
        if(countUp >= spawnInterval)
        {
            GameObject temp = Instantiate(bodyParts[0], markerManager.transform.position, markerManager.transform.rotation, transform);
            if (!temp.GetComponent<MarkerManager>())
                temp.AddComponent<MarkerManager>();
            if (!temp.GetComponent<MarkerManager>())
            {
                temp.AddComponent<Rigidbody2D>();
            }
            snakeBody.Add(temp);
            bodyParts.RemoveAt(0);
            temp.GetComponent<MarkerManager>().ClearMarkers();
            countUp = 0;
        }
    }
}
