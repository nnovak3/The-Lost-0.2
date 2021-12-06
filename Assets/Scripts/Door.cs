using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Check if console has been clicked, check# of bosses remaining

public class Door : MonoBehaviour
{
    bool consoleClick = false;
    bool miniBoss = true; 
    bool miniBoss2 = true;
    bool tutorialEnemy = true;
    bool keyCard = true;
    bool allWeapons = false;

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
        if (GameObject.FindWithTag("tutorialEnemy") == null)
        {
            tutorialEnemy = false;
        }
        if(GameObject.Find("Key Card") == null){
            keyCard = false;   
        }
        if(GameObject.Find("Player_0").transform.childCount == 3)
        {
            allWeapons = true;
        }

        //if tag == tutorial
        if (gameObject.CompareTag("Tutorial") == true){
            if (consoleClick == true)//if console has been interacted with
            {
                Destroy(gameObject);
            }
        }

        //opens miniboss doors
        if (gameObject.CompareTag("tutorialDoor") == true)
        {
            if (tutorialEnemy == false)
            {
                Destroy(gameObject);
            }
        }
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
            if (miniBoss2 == false && miniBoss == false && keyCard == false && allWeapons == true) //&& weapon got, add later
            {
                Destroy(gameObject);
            }
        }
    }
}
