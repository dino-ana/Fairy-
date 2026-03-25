using UnityEngine;

public class PipeHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FairyScript fairy = other.GetComponent<FairyScript>();

        if (fairy != null)
        {
            fairy.Die();
        }
    }
}