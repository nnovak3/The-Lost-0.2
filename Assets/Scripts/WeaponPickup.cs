using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : MonoBehaviour {

	private void Start () 
    {

	}
	
	private void Update () 
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           // Destroy(gameObject);
        }        
    }
}
