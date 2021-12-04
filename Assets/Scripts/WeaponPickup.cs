using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject player;
    public PlayerCombat combatScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player1;
    public float pickUpRange;
    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
    }

    public void Update()
    {
        Vector2 distanceToPlayer = player1.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.F) && !slotFull) PickUp();

        
    }
    
    private void PickUp()
    {
        equipped = true;
        slotFull = true;
        combatScript.enabled = true;
    }

    
}
