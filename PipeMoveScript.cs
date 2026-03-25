using UnityEngine;

public class PipePairMove : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -20f)
        {
            Destroy(gameObject);
        }
    }
}