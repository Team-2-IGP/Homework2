using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private SpriteRenderer sr;

    public float moveSpeed = 5f;
    float horizontalMovement = 1; //positive - right, negative - left, 0 - not moving
    public bool moveLeft = false;

    //to check if needs to turn around
    public LayerMask interactLayer;

    //to provide delay between change in enemy movemnt
    public float changeDelay = 2f; //time in seconds
    float nextChange = 0f;  // 0 is default, should not register it

    //total enemy count number
    public static int enemyTotal = 0;
    //total defeated enemies
    public static int enemyDown = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //grab other elements attached to this GO for use
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();


        //set layer masks
        interactLayer = LayerMask.GetMask("walls", "Enemy");

        enemyTotal++;
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
            Debug.Log("hit wall");
            Debug.Log(nextChange);
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

    void killEnemy(){
        enemyDown++;
        sr.enabled = false;
    }

    int getEnemyTotal(){
        return enemyTotal;
    }

    int getEnemyDown(){
        return enemyDown;
    }
}


