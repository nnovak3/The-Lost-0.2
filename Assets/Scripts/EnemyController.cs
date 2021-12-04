using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float range = 10.0f; // How close the player must be for enemy to start shooting
    public float cooldown = 1.0f; // How many seconds between shots
    public float enemyDamage = 10.0f;
    public float projectileSpeed = 7.0f;
    public float maxHealth = 30f;
    public GameObject projectilePrefab;
    

    private float health;

    private GameObject player;
    private GameObject projectile;
    private float count; // Time since enemy last fired
    private float distToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;
        //StartCoroutine(fire());
    }

    private void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(count >= cooldown)
        {
            Debug.Log("time!");
            if(distToPlayer <= range)
            {
                FireWeapon();
            }

            count = 0;
        }

        //Debug.Log("count: " + count + " ... dist: " + distToPlayer);
        count += Time.deltaTime;
    }

    void FireWeapon()
    {
        float moveX = player.transform.position.x - gameObject.transform.position.x;
        float moveY = player.transform.position.y - gameObject.transform.position.y;

        projectile = Instantiate<GameObject>(projectilePrefab);
        projectile.GetComponent<Projectile>().EnemyProjDamage = enemyDamage;
        projectile.transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, -2);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector3(moveX, moveY, 0) * projectileSpeed;
        projectile.GetComponent<Projectile>().target = player.transform.position;
        projectile.GetComponent<Projectile>().projectileSpeed = projectileSpeed;
        projectile.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, projectileSpeed * Time.deltaTime);
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
