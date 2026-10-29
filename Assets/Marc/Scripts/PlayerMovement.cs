using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //A / D: Move Left / Right
    //Spacebar: Jump

    public int curHP = 100;
    public int maxHP = 100;
    public HealthBar HPView;

    public float moveSpd = 8f;
    public float jumpSpd = 14f;
    public float dashSpd = 20f;

    private bool onGround;
    private bool lWallHit;
    private bool rWallHit;
    private float coyoteTime = 5.0f;
    private float moveDir = 0.0f;

    public PlayerInput input;
    public Transform groundCheckA;
    public Transform lWallCheckA;
    public Transform rWallCheckA;
    public Transform groundCheckB;
    public Transform lWallCheckB;
    public Transform rWallCheckB;
    public LayerMask groundLayer;

    public LayerMask enemyLayer;
    public BoxCollider2D hurtBox;
    private bool enemyDamage;

    private Rigidbody2D rb;

    //Set up player input (new input system) and rigidbody.
    private void Awake(){
        input = new PlayerInput();   

        rb = GetComponent<Rigidbody2D>();

        input.Player.Walk.performed += ctx => moveDir = Mathf.Round(ctx.ReadValue<float>());
        input.Player.Walk.canceled += ctx => moveDir = 0.0f;

        input.Player.Jump.performed += ctx => Jump();
        input.Player.Jump.canceled += ctx => JumpCancel();

        input.Enable();
    }

    //Move player left or right
    private void Update(){
        float actualMoveDir = moveDir; // moveDir is the input; actualMoveDir is the actual direction we are going to go

        if ((actualMoveDir < -0.1) && (lWallHit)) { actualMoveDir = 0.0f; }
        if ((actualMoveDir > 0.1) && (rWallHit)) { actualMoveDir = 0.0f; }

        rb.linearVelocity = new Vector2(actualMoveDir * moveSpd, rb.linearVelocity.y);
    }

    //Check if player is on ground and update onGround accordingly
    private void FixedUpdate(){
        onGround = Physics2D.OverlapArea(groundCheckA.position, groundCheckB.position, groundLayer);
        lWallHit = Physics2D.OverlapArea(lWallCheckA.position, lWallCheckB.position, groundLayer);
        rWallHit = Physics2D.OverlapArea(rWallCheckA.position, rWallCheckB.position, groundLayer);

        if (onGround){
            coyoteTime = 5.0f;
        }else{ coyoteTime --; }
    }

    //Jump if player is on ground
    private void Jump(){
        if (coyoteTime > 0.0f){
            AudioManager.Instance.PlaySFX(AudioManager.Instance.JumpSound);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpd);
            coyoteTime = 0.0f;
        }
    }

    //Cancel jump if jump button is released early
    private void JumpCancel(){
        if ((!onGround) && (rb.linearVelocity.y > 0)){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, (rb.linearVelocity.y * 0.35f));
        }
    }

    public bool enemyHurt(){
        enemyDamage = Physics2D.OverlapArea(groundCheckA.position, groundCheckB.position, enemyLayer);
        if (hurtBox.IsTouchingLayers(enemyLayer)){ return false; }
        if (enemyDamage) return true;
        else return false;
    }

    public void changeHP(int hpChange){
        if(hpChange < 0){
            AudioManager.Instance.PlaySFX(AudioManager.Instance.DamageSound);
            Score.Instance.changeScore(-3);
        } else
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.healthpickupSound);
            Score.Instance.changeScore(+5);
        }
        curHP += hpChange;
        HPView.SetHealth(curHP);
        if (curHP <= 0) { killPlayer(); }
        if (curHP > maxHP) { curHP = maxHP; }
    }

    private void killPlayer(){
        SceneManager.LoadScene("DeathScreen");

    }
}
