using UnityEngine;

public class HealingCollectable : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private SpriteRenderer sr;

    //healing vars
    private GameObject playerObject; 
    private PlayerMovement player; //Player object reference.
    public int healingVal = 10; //Amount of healing provided

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //grab other elements attached to this GO for use
        boxCollider = GetComponent<BoxCollider2D>();
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

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.gameObject.tag == "Player"){
            player.changeHP(healingVal);
            boxCollider.enabled = false;
            sr.enabled = false;
        }
    }
}
