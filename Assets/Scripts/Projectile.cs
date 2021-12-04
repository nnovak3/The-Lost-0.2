using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 target;
    public float projectileSpeed = 1.0f;
    public float EnemyProjDamage = 10f;
    public float PlayerProjDamage = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        StartCoroutine(destroyProjectile());
    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);
        //if(transform.position.x == target.x && transform.position.y == target.y)
       // {
       //     Destroy(gameObject);
       // }
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
        else if (other.tag == "MiniBoss2" && projectile.tag == "PlayerProjectile")
        {
            Debug.Log("Miniboss Enemy detected.");
            Destroy(projectile);

            other.GetComponent<EnemyController>().TakeDamage(PlayerProjDamage);
        }
        else if (other.tag == "tutorialEnemy" && projectile.tag == "PlayerProjectile")
        {
            Debug.Log("tutorialEnemy Enemy detected.");
            Destroy(projectile);

            other.GetComponent<EnemyController>().TakeDamage(PlayerProjDamage);
        }
        else if (other.tag == "Player" && projectile.tag == "EnemyProjectile")
        {
            Debug.Log("Player detected.");
            Destroy(projectile);

            other.GetComponent<PlayerController>().TakeDamage(EnemyProjDamage);
        }
        else if (other.tag == "Boss" && projectile.tag == "PlayerProjectile")
        {
            Destroy(projectile);

            other.GetComponent<EnemyController>().TakeDamage(PlayerProjDamage);
        }
        else if (other.tag == "Wall")
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
