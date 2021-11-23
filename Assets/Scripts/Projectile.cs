using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject player;
    public float EnemyProjDamage = 10f;
    public float PlayerProjDamage = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        
        
        if(gameObject.tag == "PlayerProjectile")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        }
        
        StartCoroutine(destroyProjectile());
    }

    void Update()
    {
        
    }

    // Detects when the projectile makes a collision. If it hits an enemy and originates from player it damages enemy, if it hits player and originates from enemy then it damages player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        GameObject projectile = collision.otherCollider.gameObject;

        rb = GetComponent<Rigidbody2D>();

        // First thing we do when a collision occurs is set velocity to 0 to stop any weird sliding/movements
        rb.velocity = new Vector2(0, 0);
        
        

       
        if (other.tag == "Enemy" && projectile.tag == "PlayerProjectile")
        {
            Debug.Log("Enemy detected.");
            Destroy(projectile);

            other.GetComponent<EnemyController>().TakeDamage(PlayerProjDamage);
        }
        else if (other.tag == "MiniBoss" && projectile.tag == "PlayerProjectile")
        {
            Debug.Log("Miniboss Enemy detected.");
            Destroy(projectile);

            other.GetComponent<EnemyController>().TakeDamage(PlayerProjDamage);
        }
        else if(other.tag == "Player" && projectile.tag == "EnemyProjectile")
        {
            Debug.Log("Player detected.");
            Destroy(projectile);

            other.GetComponent<PlayerController>().TakeDamage(EnemyProjDamage);
        }else if(other.tag == "Wall")
        {
            Destroy(projectile);
        }
        else
        {
            Debug.Log(other.name);
        }
    }

    // Coroutine for deleting projectile if no collision within 3 seconds
    IEnumerator destroyProjectile()
    {
        yield return new WaitForSecondsRealtime(3);
        Destroy(gameObject);
    }
}
