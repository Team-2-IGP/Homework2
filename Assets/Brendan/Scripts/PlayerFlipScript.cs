using UnityEngine;
//using PlayerMovement;


public class PlayerFlipScale : MonoBehaviour
{
    private bool isFacingRight = true;
    private PlayerMovement playerMovement;

    private SpriteRenderer spriteRender;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        spriteRender = GetComponent<SpriteRenderer>(); // Assuming the sprite is the first child of the player object
    }

    void Update()
    {
        // Replace with your input method (e.g., InputSystem or Input.GetAxisRaw)
        //float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (playerMovement.moveDir > 0)
        {
            Flip(true);
        }
        else if (playerMovement.moveDir < 0)
        {
            Flip(false);
        }
    }

    void Flip(bool facingRight)
    {
        // Toggle the orientation flag
        //isFacingRight = !isFacingRight;

        spriteRender.flipX = !facingRight;
        //// Multiply the player's x local scale by -1
        //Vector3 currentScale = transform.localScale;
        //currentScale.x *= -1;
        //transform.localScale = currentScale;

    }
}