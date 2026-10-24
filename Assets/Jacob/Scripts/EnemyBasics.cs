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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyTotal++;

        //grab other elements attached to this GO for use
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

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
}
