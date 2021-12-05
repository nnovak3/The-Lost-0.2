using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == ("Pistol"))
        {
            Debug.Log("shit works");
            col.gameObject.transform.parent = gameObject.transform;
        }
    }
}
