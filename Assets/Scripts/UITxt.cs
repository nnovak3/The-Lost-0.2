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
<<<<<<< HEAD
=======
    bool bossCheck = false;
<<<<<<< HEAD
>>>>>>> parent of 5f2df5c (Fixed some ui text)
=======
>>>>>>> parent of 5f2df5c (Fixed some ui text)


    //TODO: Force player to scroll through text
    //refine tutorial
    // Explain keycard on pickup
    //FIX TEXT SCROLLING

    // Start is called before the first frame update
    void Start()
    {
        uiText.text = ("Ugh... where am I? [press 'e' to continue] -->");
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
                uiText.text = ("Right, the infermary. Where is everybody? -->");
                promptCounter++;
                promptNo++;
            }
            else if (promptCounter == 2)
            {
                uiText.text = ("[use the 'w-a-s-d' keys to move. Walk over glowing objects to pick them up]-->");
                promptCounter++;
                promptNo++;

            }
            else if (promptCounter == 3)
            {
                uiText.text = ("[use the SPACE bar to melee]-->");
                promptCounter++;
                promptNo++;

            }
            else if (promptCounter == 4)
            {
                uiText.text = ("[Defeat the enemy in the next room to unlock the door]-->");
                promptCounter++;
                promptNo ++;
            }
            else if (promptCounter == 5)
            {
                uiText.text = ("[Once you pick up a weapon press 'q' to select, and use left click to fire the weapon]");//move this on the pickup of the weapon
                promptCounter++;
                promptNo = 0;
            }
        }
        else if (Input.GetKeyDown("e") && uiText.text != "" && promptNo == 0)//Clears text
        {
            uiText.text = "";
            promptNo = 0;
        }
        if (GameObject.FindWithTag("tutorialEnemy") == null && noEText == 0)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            uiText.text = ("Shit! What was that thing?-->");
            if (Input.GetKeyDown("e") && uiText.text == ("Shit! What was that thing?-->"))
=======
=======
>>>>>>> parent of 5f2df5c (Fixed some ui text)
            uiText.text = ("Shit! What was that thing?");
            if (Input.GetKeyDown("e") && uiText.text == ("Shit! What was that thing? -->"))
>>>>>>> parent of 5f2df5c (Fixed some ui text)
            {
                noEText++;
                uiText.text = ("Is that - did it EAT Jenkins?!");
            }
        }
        else if (usedItem == "PPAADD")
        {
            if (promptNo == 0)
            {
                uiText.text = ("[You pick up a PPAADD - Personal Pocket Access Allowing Display Device]");
                if (Input.GetKeyDown("e"))
                {
                    promptNo++;
                }
            }
            else if (promptNo == 1)
            {
                uiText.text = ("[You get the feeling that whoever came up with that name was trying way too hard to make a joke]");
                if (Input.GetKeyDown("e"))
                {
                    promptNo++;
                }
            }
            else if (promptNo == 2)
            {
                uiText.text = ("PPAADD: Hey newbie, I know you never got the grand tour of the palce before you got laid up.");
                if (Input.GetKeyDown("e"))
                {
                    promptNo++;
                }
            }
            else if (promptNo == 3)
            {
                uiText.text = ("PPAADD: Come see me up in the control room, I'll fill you in.");
                if (Input.GetKeyDown("e"))
                {
                    promptNo++;
                }
            }
            else if (promptNo == 4)
            {
                uiText.text = ("PPAADD: If Armstrong is up to her \"hazing rituals\" again and locked the door, the access console near the exit will open it.");
                if (Input.GetKeyDown("e"))
                {
                    promptNo++;
                }
            }
            else if (promptNo == 5)
            {
                uiText.text = ("PPAADD: -- Security Chief Gagarin");
                if (Input.GetKeyDown("e"))
                {
                    promptNo++;
                }
            }
            else if (promptNo == 6)
            {
                uiText.text = ("");
                promptNo = 0;
            }
        }
        else if (GameObject.Find("Final Boss") == null)
        {

            promptNo = 0;
            uiText.text = ("Sta - *kzzzt* co- *kzzzt* -in *kzzzt*");
            if (Input.GetKeyDown("e"))
            {
                promptNo++;
            }

            if (promptNo == 1)
            {
                uiText.text = ("Station Delta Sierra Niner, come in!");
                if (Input.GetKeyDown("e"))
                {
                    promptNo++;
                }
            }
            if (promptNo == 2)
            {
                uiText.text = ("This is Station Delta Sierra Niner");
                if (Input.GetKeyDown("e"))
                {
                    promptNo++;
                }
            }
            if (promptNo == 3)
            {
                uiText.text = ("Finally! We've been trying to get ahold of you guys for an hour! What's going on there?");
                if (Input.GetKeyDown("e"))
                {
                    promptNo++;
                }
            }
            if (promptNo == 4)
            {
                uiText.text = ("We - the station's been attacked by - things. I'm the only one left alive.");
                if (Input.GetKeyDown("e"))
                {
                    promptNo++;
                }
            }
            if (promptNo == 5)
            {
                uiText.text = ("Hang in there. We're sending someone to get you.");
                if (Input.GetKeyDown("e"))
                {
                    promptNo++;
                }
            }
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 5f2df5c (Fixed some ui text)
        else if(usedItem == "Key")
        {
            uiText.text = ("Looks like some sort of key card. Might come in handy.");
        }
>>>>>>> parent of 5f2df5c (Fixed some ui text)
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
            uiText.text = ("");
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        int count = 0;
        bool key = false;

        if(GameObject.Find("Key") != null)
        {
            key = true;
        }

        if (col.gameObject.tag == ("tutorialDoor"))
        {
            uiText.text = ("Hmm, this door is locked.");
        }
        if (col.gameObject.tag == ("MiniBossDoor") | col.gameObject.tag == ("MiniBossDoor2"))
        {
            uiText.text = ("[The door is blocked by debries, and the creature isn't about to let you move it]");
        }
        if (col.gameObject.tag == ("Boss"))
        {
            if (key == false)
            {
                uiText.text = ("[There's a keycard slot next to this door. Doesn't look like it will open without one.]");
                if (GameObject.Find("Player_0").transform.childCount < 3)
                {
                    uiText.text = ("[You hear something big moving behind the door. Too big for your little handgun to take. There's gotta be something bigger around here.]");
                }
            }

            else
                {
                if (GameObject.Find("Player_0").transform.childCount < 3)
                    {
                      uiText.text = ("[You hear something big moving behind the door. Too big for your little handgun to take. There's gotta be something bigger around here.]");
                     }
                }
            }
    }


}


