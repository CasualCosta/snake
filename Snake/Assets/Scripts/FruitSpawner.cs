using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] GameObject fruitPrefab;
    [SerializeField] Transform fruitHolder;
    [SerializeField] Transform[] limits = new Transform[2];
    [SerializeField] float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnFruit();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void SpawnFruit()
    {
        Vector3 pos = new Vector3
            (
                Random.Range(limits[0].position.x, limits[1].position.x),
                Random.Range(limits[0].position.y, limits[1].position.y),
                Random.Range(limits[0].position.z, limits[1].position.z)
            );
        Fruit fruit = Instantiate(fruitPrefab, pos, transform.rotation).GetComponent<Fruit>();
        fruit.onPickUp.AddListener(SpawnFruit);
        fruit.transform.parent = fruitHolder;
    }
}
