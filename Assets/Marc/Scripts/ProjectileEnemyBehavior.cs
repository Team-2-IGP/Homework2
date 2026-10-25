using UnityEngine;

public class ProjectileEnemyBehavior : MonoBehaviour
{

    public GameObject projectile;
    public Transform projectilePos;
    private float shotTimer = 0.0f;
    private float timerMax = 2.0f;

    private SpriteRenderer sr;

    private void Start(){
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update(){
        shotTimer += Time.deltaTime;

        if((shotTimer >= timerMax) && (sr.enabled == true)){
            shotTimer = 0;
            fireProjectile();
        }
    }

    private void fireProjectile(){
        Instantiate(projectile, projectilePos);
    }
}
