using UnityEngine;
using UnityEngine.InputSystem;

public class FairyScript : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Movement")]
    public float flapStrength = 10f;

    [Header("Rotation")]
    public float tiltUpAngle = 30f;
    public float tiltDownAngle = -60f;
    public float rotationSpeed = 5f;

    private bool isDead = false;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(0f, flapStrength);
        }

        float t = Mathf.InverseLerp(-5f, 5f, rb.linearVelocity.y);
        float angle = Mathf.Lerp(tiltDownAngle, tiltUpAngle, t);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, 0, angle),
            rotationSpeed * Time.deltaTime
        );
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false;

        if (GameManager.instance != null)
            GameManager.instance.ShowGameOver();
    }
}