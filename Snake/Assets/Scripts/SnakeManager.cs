using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    [SerializeField] float spawnInterval = 0.2f;

    [SerializeField] List<GameObject> bodyParts = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> snakeBody = new List<GameObject>();
    [SerializeField] SnakeMovement snakeMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        if (snakeMovement.enabled)
            snakeMovement.enabled = false;
        StartCoroutine(CreationCoroutine());
    }

    IEnumerator CreationCoroutine()
    {
        while(bodyParts.Count > 0)
        {

            yield return new WaitForSeconds(spawnInterval);
            Transform spawnPoint = snakeBody.Count == 0 ? transform : snakeBody[snakeBody.Count - 1].transform;
            
            GameObject temp = Instantiate(bodyParts[0], spawnPoint.transform.position, spawnPoint.transform.rotation, transform);
            if (!temp.GetComponent<MarkerManager>())
                temp.AddComponent<MarkerManager>();
            if (!temp.GetComponent<MarkerManager>())
                temp.AddComponent<Rigidbody2D>();
            snakeBody.Add(temp);
            if(snakeBody.Count == 1)
            {
                snakeMovement.enabled = true;
                snakeMovement.snakeManager = this;
                temp.AddComponent<SnakeHead>();
            }
            bodyParts.RemoveAt(0);
            temp.GetComponent<MarkerManager>().ClearMarkers();

        }
    }
}
