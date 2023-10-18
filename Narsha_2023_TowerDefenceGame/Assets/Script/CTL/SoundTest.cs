using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySFXSound(SoundManager.sfxClips.sound3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
