using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float projectileSpeed = 1.0f;
    public float maxHealth = 30f;
    public GameObject projectilePrefab;
    

    private float health;

    private GameObject player;
    private GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;
        StartCoroutine(fire());
    }

    // This is a temporary coroutine to make the enemy fire bullets
    IEnumerator fire()
    {
        while(true)
        {

            float moveX = player.transform.position.x - gameObject.transform.position.x;
            float moveY = player.transform.position.y - gameObject.transform.position.y;

            projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, -2);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(moveX, moveY, 0) * projectileSpeed;

            yield return new WaitForSecondsRealtime(2);
        }
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
