using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    public float projectileSpeed = 2.0f;
    public GameObject projectilePrefab;

    private GameObject projectile;
    
    public Text AmmoCT;

    private void Start()
    {
        //Sets up the ammmo counter. Might need to move this?
        GameObject ammoC = GameObject.Find("AmmoCount");//Locates AmmoCountUI object
        AmmoCT = ammoC.GetComponent<Text>();//Get ammo count text field
        AmmoCT.text = "0" ; // Sets initial Ammo #
    }
    
    private void Update()
    {
        // Left mouse click to fire weapon
        if (Input.GetMouseButtonUp(0))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        projectile = Instantiate<GameObject>(projectilePrefab);
        projectile.transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, 0);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, 1, 0) * projectileSpeed;
        AmmoShoot();
    }

    private void AmmoShoot()
    {
        int ammoNum = int.Parse(AmmoCT.text);//gets current ammo count
        ammoNum -= 1;// Subtracts ammo
    }
}
