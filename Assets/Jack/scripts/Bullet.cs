using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 5f;
    private float direction;
    private Rigidbody2D rb;

    public void Setup(float dir)
    {
        direction = dir;
        rb = GetComponent<Rigidbody2D>();

        // Flip the bullet sprite if shooting left
        if (direction < 0)
        {
            transform.Rotate(0f, 0f, 180f);
        }

        rb.linearVelocity = new Vector2(direction * speed, 0);
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyBasics>().killEnemy();

            Destroy(gameObject);
        }

        if (!collision.CompareTag("Player") && !collision.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}
