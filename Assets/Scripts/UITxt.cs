using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITxt : MonoBehaviour
{
    public TMP_Text uiText;
    int promptCounter = 0;
    int promptNo = 0;
    bool trigEnter = false;
    bool trigExit = true;
    int noEText = 0;
    Collider2D checker;
    string usedItem = "";

    // Start is called before the first frame update
    void Start()
    {
        uiText.text = ("Ugh... where am I? [press 'e' to continue]");
        promptCounter++;
        promptNo++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && uiText.text == "" || Input.GetKeyDown("e") && promptNo != 0)
        {
            if (promptCounter == 1)
            {
                uiText.text = ("Right, the infermary. Where is everybody?");
                promptCounter++;
                promptNo++;
            }
            else if (promptCounter == 2)
            {
                uiText.text = ("[use the 'w-a-s-d' keys to move. Walk over glowing objects to pick them up]");
                promptCounter++;
                promptNo++;

            }
            else if (promptCounter == 3)
            {
                uiText.text = ("[use the SPACE bar to melee]");
                promptCounter++;
                promptNo++;

            }
            else if (promptCounter == 4)
            {
                uiText.text = ("[Defeat the enemy in the next room to unlock the door]");
                promptCounter++;
                promptNo ++;
            }
            else if (promptCounter == 5)
            {
                uiText.text = ("[Once you pick up a weapon press 'q' to select, and use left click to fire the weapon]");
                promptCounter++;
                promptNo = 0;
            }
            else if (usedItem == "PPAADD")
            {
                if (promptNo == 0)
                {
                    uiText.text = ("[You pick up a PPAADD - Personal Pocket Access Allowing Display Device]");
                    promptNo++;
                }
                else if (promptNo == 1)
                {
                    uiText.text = ("[You get the feeling that whoever came up with that name was trying way too hard to make a joke]");
                    promptNo++;
                }
                else if (promptNo == 2)
                {
                    uiText.text = ("PPAADD: Hey newbie, I know you never got the grand tour of the palce before you got laid up.");
                    promptNo++;
                }
                else if (promptNo == 3)
                {
                    uiText.text = ("PPAADD: Come see me up in the control room, I'll fill you in.");
                    promptNo++;
                }
                else if (promptNo == 4)
                {
                    uiText.text = ("PPAADD: If Armstrong is up to her \"hazing rituals\" again and locked the door, the access console near the exit will open it.");
                    promptNo++;
                }
                else if (promptNo == 5)
                {
                    uiText.text = ("PPAADD: -- Security Chief Gagarin");
                    promptNo++;
                }
                else if (promptNo == 6)
                {
                    uiText.text = ("");
                    promptNo = 0;
                }
            }

        }
        else if (Input.GetKeyDown("e") && uiText.text != "" && promptNo == 0)//Clears text
        {
            uiText.text = "";
            promptNo = 0;
        }
        if (GameObject.FindWithTag("tutorialEnemy") == null && noEText == 0)
        {
            uiText.text = ("Shit! What was that thing?");
            noEText++;
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == ("interactable"))
        {
            //Debug.Log("Entered");
            trigEnter = true;
            trigExit = false;
            usedItem = obj.gameObject.name;

        }

    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.tag == ("interactable"))
        {
            //Debug.Log("Exited");
            trigEnter = false;
            trigExit = true;
            usedItem = "";
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == ("tutorialDoor"))
        {
            uiText.text = ("Hmm, this door is locked.");
        }
        if (col.gameObject.tag == ("MiniBossDoor") | col.gameObject.tag == ("MiniBossDoor2"))
        {
            uiText.text = ("This door is locked, defeat the miniboss.");
        }
        if (col.gameObject.tag == ("Boss"))
        {
            uiText.text = ("This door is locked, defeat both minibosses, and obtain the super weapon.");
        }
    }


}


