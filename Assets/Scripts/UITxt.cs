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
        if (Input.GetKeyDown("e") && uiText.text == "" || Input.GetKeyDown("e") && promptNo != 0 )
        {
            if(promptCounter == 1)
            {
                uiText.text = ("Right, the infermary. Where is everybody? [press 'e' to continue]");
                promptCounter++;
                promptNo++;      
            }
            else if (promptCounter == 2)
            {
                uiText.text = ("[use the 'wasd' keys to move. Use 'f' to interact with objects][press 'e' to continue]");
                promptCounter++;
                promptNo ++;

            }
            else if (promptCounter == 3)
            {
                uiText.text = ("[use the spacebar to melee with your knife][press 'e' to continue]");
                promptCounter++;
                promptNo ++;

            }
            else if (promptCounter == 4)
            {
                uiText.text = ("Melee the enemy in the next room to unlock the door [press 'e' to end instructions]");
                promptCounter++;
                promptNo = 0;

            }
            else if(usedItem == "PPAADD")
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
        
          
}


/*void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == ("interactable"))
        {
            Debug.Log("Entered");
            trigEnter = true;
            trigExit = false;
            uiText.text = ("Hey rookie. I know you never got the grand tour of the palce before you got laid up");
           
        }
    }*/