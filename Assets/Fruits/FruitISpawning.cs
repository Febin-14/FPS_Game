using UnityEngine;

public class FruitISpawning : MonoBehaviour
{
    public GameObject fruitPrefab;
    public Transform[] spawnPoints;
    public float delayTimer;
    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnFruit();
            timer = delayTimer;
        }
    }
    void SpawnFruit()
    {
        Instantiate(fruitPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
    }
}

