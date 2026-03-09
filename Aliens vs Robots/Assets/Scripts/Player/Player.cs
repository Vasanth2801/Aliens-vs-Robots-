using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float speed = 5f;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Inputs")]
    [SerializeField] private float moveInput;

    void Update()
    {
        moveInput = Input.GetAxis("Vertical") * Time.deltaTime;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x , moveInput * speed);
    }
}