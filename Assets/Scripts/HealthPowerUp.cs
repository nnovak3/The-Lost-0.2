using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public float health = 50; // How much health to heal player

    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<PlayerController>().HealthPowerUp(health);
        Destroy(gameObject);
    }

    
}
