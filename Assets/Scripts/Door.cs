using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Check if console has been clicked, check# of bosses remaining

public class Door : MonoBehaviour
{
    bool consoleClick = false;
    bool miniBoss = true; 
    bool miniBoss2 = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if minibosses are dead, sets bools as such

        if(GameObject.FindWithTag("MiniBoss") == null)
        {
            miniBoss = false;
        }
        if (GameObject.FindWithTag("MiniBoss2") == null)
        {
            miniBoss2 = false;
        }

        //if tag == tutorial
        if (gameObject.CompareTag("Tutorial") == true){
            if (consoleClick == true)//if console has been interacted with
            {
                Destroy(gameObject);
            }
        }

        //opens miniboss doors
        if (gameObject.CompareTag("MiniBossDoor") == true)
        {
            if (miniBoss == false)
            {
                Destroy(gameObject);
            }
        }

        if (gameObject.CompareTag("MiniBossDoor2") == true)
        {
            if (miniBoss2 == false)
            {
                Destroy(gameObject);
            }
        }

        //opens final door
        if (gameObject.CompareTag("Boss") == true)
        {
            if (miniBoss2 == false && miniBoss == false) //&& weapon got, add later
            {
                Destroy(gameObject);
            }
        }
    }
}
