using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public bool minisDead;
    public bool gotSuper;
    public AudioSource[] bgMusic;
    //public AudioSource supwepMusic;
    //public Audiosource bossfight;
    // Start is called before the first frame update
    void Start()
    {
        minisDead = false;
        gotSuper = false;
        bgMusic = gameObject.GetComponents<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void MusicRules()
    {
        if(minisDead == false)
        {
            bgMusic[0].Play();
        }
        else
        {
            if (gotSuper == false)
            {
                bgMusic[0].Stop();
                bgMusic[1].Play();
            }
        }
    }
}
