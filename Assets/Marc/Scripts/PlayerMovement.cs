using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //A / D: Move Left / Right
    //Spacebar: Jump
    //Left Shift: Dash

    //TODO:
    //Implement Dash
    //Fix "Wall Cling" Glitch
    //Coyote Time???

    public float moveSpd = 8f;
    public float jumpSpd = 10f;
    public float groundCheckRadius = 0.2f;

    private float moveDir;
    private bool onGround;

    public PlayerInput input;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    //Set up player input (new input system) and rigidbody.
    private void Awake(){
        input = new PlayerInput();   

        rb = GetComponent<Rigidbody2D>();

        input.Player.Walk.performed += ctx => moveDir = Mathf.Round(ctx.ReadValue<float>());
        input.Player.Walk.canceled += ctx => moveDir = 0.0f;

        input.Player.Jump.performed += ctx => Jump();
        input.Player.Jump.canceled += ctx => JumpCancel();

        input.Player.Dash.performed += ctx => Dash();

        input.Enable();
    }

    //Move player left or right
    private void Update(){
        rb.linearVelocity = new Vector2(moveDir * moveSpd, rb.linearVelocity.y);
    }

    //Check if player is on ground and update onGround accordingly
    private void FixedUpdate(){
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    //Jump if player is on ground
    private void Jump(){
        if (onGround){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpd);
        }
    }

    //Cancel jump if jump button is released early
    private void JumpCancel(){
        if ((!onGround) && (rb.linearVelocity.y > 0)){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, (rb.linearVelocity.y * 0.35f));
        }
    }

    //Player dash
    private void Dash(){

    }
}
