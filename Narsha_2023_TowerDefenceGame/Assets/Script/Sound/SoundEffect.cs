using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    
    public AudioSource sound;

    public AudioClip attack;

    public AudioClip run;
    
    void WalkSound()
    {
        sound.clip = run;
        sound.Play();
    }
    
    void AttackSound()
    {
        sound.clip = attack;
        sound.Play();
    }
}
