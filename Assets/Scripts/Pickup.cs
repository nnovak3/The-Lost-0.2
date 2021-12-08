using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    List<GameObject> weapons;
    private int weaponSelected = 0;
    private int numWeapons = -1;

    public GameObject superWeapon;

    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<GameObject>();
        getPlayerWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            Debug.Log("player is switching weapons " + weaponSelected + " " + numWeapons);

            weapons[weaponSelected].SetActive(false);

            if(weaponSelected >= numWeapons)
            {
                weaponSelected = 0;
            }
            else
            {
                weaponSelected++;
            }

            weapons[weaponSelected].SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == ("Pistol"))
        {
            col.gameObject.transform.parent = gameObject.transform;
            col.gameObject.SetActive(false);
            col.gameObject.GetComponent<WeaponController>().enabled = true;
            weapons.Add(col.gameObject);

            Debug.Log("pistol added");
            numWeapons++;

        }else if(col.gameObject.name == ("SuperWeapon"))
        {
            
            col.gameObject.transform.parent = gameObject.transform;
            col.gameObject.SetActive(false);
            col.gameObject.transform.GetChild(0).GetComponent<SuperWeaponController>().enabled = true;
            weapons.Add(col.gameObject);
            numWeapons++;

            if(transform.localScale.x >= 0)
            {
                col.gameObject.transform.localScale = new Vector3(-0.1f, 0.1f, 1);
            }
            else
            {
                col.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            }

           // Debug.Log(weapons);
        }

        if(col.gameObject.name == ("Key"))
        {
            Debug.Log("test");
            Destroy(col.gameObject);
        }
    }

    void getPlayerWeapons()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            weapons.Add(transform.GetChild(i).gameObject);
            Debug.Log("added");
            numWeapons++;
        }
    }
}
