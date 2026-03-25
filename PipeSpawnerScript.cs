using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipePairPrefab;
    public float spawnRate = 2f;
    public float moveSpeed = 3f;
    public float minY = -2f;
    public float maxY = 2f;

    private float timer;

    void Start()
    {
        SpawnPipePair();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipePair();
            timer = 0f;
        }
    }

    void SpawnPipePair()
    {
        float randomY = Random.Range(minY, maxY);

        GameObject pipe = Instantiate(
            pipePairPrefab,
            new Vector3(transform.position.x, randomY, 0f),
            Quaternion.identity
        );

        PipePairMove moveScript = pipe.GetComponent<PipePairMove>();
        if (moveScript != null)
        {
            moveScript.moveSpeed = moveSpeed;
        }
    }
}