using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public GameObject healthBar;
    public float speed;

    private Slider healthSlider;
    private float playerHealth;
    
    private Vector3 move;
    private float deltaX;
    private float deltaY;
    private RaycastHit2D hit;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        // Default values for player health
        playerHealth = 100f;

        boxCollider = GetComponent<BoxCollider2D>();
        healthSlider = healthBar.GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        deltaX = Input.GetAxisRaw("Horizontal");
        deltaY = Input.GetAxisRaw("Vertical");

        move = new Vector3(deltaX, deltaY, 0);

        // Swap sprite direction; if player is moving right, default sprite orientation. If player moving left, flip the sprite by setting scale.x to -1
        if(move.x > 0)
        {
            transform.localScale = new Vector3(6, 6, 6);
        }else if(move.x < 0)
        {
            transform.localScale = new Vector3(-6, 6, 6);
        }

        // We check to see if the player will collide with anything before moving them
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, move.y), Mathf.Abs(move.y * Time.deltaTime), LayerMask.GetMask("Player", "Collidable"));
        if (hit.collider == null) // BoxCast() returns a RayCastHit2D object; the Collider property of the result will be NULL if nothing was hit, meaning the player can move
        {
            transform.Translate(0, move.y * Time.deltaTime * speed, 0);
        }
        // We just checked for collisions in the y direction, now we need to check x
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(move.x, 0), Mathf.Abs(move.x * Time.deltaTime), LayerMask.GetMask("Player", "Collidable"));
        if (hit.collider == null) 
        {
            transform.Translate(move.x * Time.deltaTime * speed, 0, 0);
        }

        healthSlider.value = playerHealth;

    }

    public void HealthPowerUp(float health)
    {
        playerHealth += health;
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
    }

    // Coroutine for removing power up
    IEnumerator destroyPowerUp(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        //Destroy(gameObject);
    }
}
