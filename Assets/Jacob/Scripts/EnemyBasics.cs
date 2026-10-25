using UnityEngine;

public class EnemyBasics : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private SpriteRenderer sr;

    //total enemy count number
    public static int enemyTotal = 0;
    //total defeated enemies
    public static int enemyDown = 0;

    private GameObject playerObject;
    private PlayerMovement player; //Player object reference.
    public int enemyDamage = -5; //Amount of damage enemy should deal.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyTotal++;

        //grab other elements attached to this GO for use
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        //get player object and pull script from it
        playerObject = GameObject.FindWithTag("Player");
    
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerMovement>();
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void killEnemy(){
        enemyDown++;
        sr.enabled = false;
        rb.simulated = false;
        boxCollider.enabled = false;
    }

    public static int getEnemyTotal(){
        return enemyTotal;
    }

    public static int getEnemyDown(){
        return enemyDown;
    }

    //Collide with player, check if enemy should be destroyed.
    void OnCollisionEnter2D(Collision2D collide){
        if(collide.gameObject.tag == "Player"){
            if (player.enemyHurt() == true){
                killEnemy();
            }else{
                player.changeHP(enemyDamage);
            }
        }

        if(collide.gameObject.tag == "FallZone"){
            killEnemy();
        }

    }
}
