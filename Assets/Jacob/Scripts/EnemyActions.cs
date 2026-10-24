using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    public float moveSpeed = 5f;
    float horizontalMovement = 1; //positive - right, negative - left, 0 - not moving
    public bool moveLeft = false;

    //to check if needs to turn around
    public LayerMask interactLayer;

    //to provide delay between change in enemy movemnt
    public float changeDelay = 2f; //time in seconds
    float nextChange = 0f;  // 0 is default, should not register it

    //Sorry, Jacob, for modifying your code, but it was the only way I could figure this out without causing a ton of bugs. -Marc
    public PlayerMovement player; //Player object reference.
    public int enemyDamage = -5; //Amount of damage enemy should deal.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //grab other elements attached to this GO for use
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        //set layer masks
        interactLayer = LayerMask.GetMask("walls", "Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        //set movemnt
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);

        //detect wall collision
        if(boxCollider.IsTouchingLayers(interactLayer) && horizontalMovement != 0 && Time.time >= nextChange) {
            horizontalMovement = 0;
            nextChange = Time.time + changeDelay;
        }
        
        //change direction
        if(Time.time >= nextChange && !moveLeft && horizontalMovement == 0 && nextChange != 0){
            horizontalMovement = -1;
            moveLeft = true;
            nextChange = Time.time + 0.05f; //buffer to get off the wall
            
        }else if(Time.time >= nextChange && moveLeft && horizontalMovement == 0 && nextChange != 0){
            horizontalMovement = 1;
            moveLeft = false;
            nextChange = Time.time + 0.05f; //buffer to get off the wall
        }
    }

    //Collide with player, check if enemy should be destroyed.
    void OnCollisionEnter2D(Collision2D collide){
        if(collide.gameObject.tag == "Player"){
            if (player.enemyHurt() == true){
                Destroy(gameObject);
            }else{
                player.changeHP(enemyDamage);
            }
        }
    }
}
