using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{

    public float projSpeed = 5.0f;
    public int bulletDamage = -5;
    private float projLife = 5.0f;

    private GameObject playerObject;
    private PlayerMovement player;
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    public LayerMask wallLayers;
    public LayerMask playerLayer;

    void Start(){
        AudioManager.Instance.PlaySFX(AudioManager.Instance.shootSound);
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        
        //get player object and pull script from it (Copied from EnemyBasics.cs)
        playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null){
            player = playerObject.GetComponent<PlayerMovement>();
        }

        wallLayers = LayerMask.GetMask("walls", "Ground", "Enemy");
        playerLayer = LayerMask.GetMask("player");
        
        Vector3 dir = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(dir.x, dir.y).normalized * projSpeed;
    }

    void Update(){
        projLife -= Time.deltaTime;
        if(projLife <= 0.0f){
            Destroy(gameObject);
        }
        if(circleCollider.IsTouchingLayers(wallLayers)){
            Destroy(gameObject);
        }
        if(circleCollider.IsTouchingLayers(playerLayer)){
            player.changeHP(bulletDamage);
            Destroy(gameObject);
        }
    }
}
