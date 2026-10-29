using UnityEngine;

public class AmmoCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().AddAmmo(1);
            Destroy(gameObject);
        }
    }
}
