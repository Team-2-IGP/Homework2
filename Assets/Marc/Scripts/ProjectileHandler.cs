using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{

    public float projSpeed = 5.0f;
    public int bulletDamage = 5;
    private GameObject playerObject;
    private PlayerMovement player;
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    public LayerMask wallLayers;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        
        //get player object and pull script from it (Copied from EnemyBasics.cs)
        playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null){
            player = playerObject.GetComponent<PlayerMovement>();
        }

        wallLayers = LayerMask.GetMask("walls", "Ground");
        
        Vector3 dir = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(dir.x, dir.y).normalized * projSpeed;
    }

    void OnCollisionEnter2D(Collision2D collide){
        if(collide.gameObject.tag == "Player"){
            player.changeHP(-bulletDamage);
            Destroy(gameObject);
        }
    }
    void Update(){
        if(circleCollider.IsTouchingLayers(wallLayers)){
            Destroy(gameObject);
        }
    }
}
