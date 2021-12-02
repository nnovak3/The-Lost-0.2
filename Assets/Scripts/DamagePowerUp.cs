using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    public float damage = 20; // How much extra damage to give the player (default is currently 10 damage in WeaponController)

    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        WeaponController[] weapons = player.GetComponentsInChildren<WeaponController>();
        foreach(WeaponController weapon in weapons)
        {
            weapon.DamagePowerUp(damage);
        }
        Destroy(gameObject);
    }
}
