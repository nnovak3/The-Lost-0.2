using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITxt : MonoBehaviour
{
    public TMP_Text uiText;
    int promptCounter = 0;
    int promptNo = 0;

    

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
            //uiText.text = "TESTING";
           
            if(promptCounter == 1)
            {
                uiText.text = ("Right, the infermary. Where is everybody?");
                promptCounter++;
                promptNo++;
               
            }
            else if (promptCounter == 2)
            {
                uiText.text = ("[use 'wasd to move. Use PLACEHOLDER to interact with objects]");
                promptCounter++;
                promptNo = 0;

            }

        }
        else if (Input.GetKeyDown("e") && uiText.text != "" && promptNo == 0)//Clears text
        {
            uiText.text = "";
        }
    }
    void onCollisionEnter(Collision obj)
    {
        if(obj.gameObject.name == "PPAADD")
        {
            uiText.text = ("Hey rookie. I know you never got the grand tour of the palce before you got laid up");
        }
    }
}
