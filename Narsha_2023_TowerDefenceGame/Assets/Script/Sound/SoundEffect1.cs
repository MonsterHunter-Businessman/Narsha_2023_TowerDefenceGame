using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect1 : MonoBehaviour
{

    public AudioSource run;

    public AudioSource attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WalkSound()
    {
        run.Play();
    }
    
}
