using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
   public AudioSource footstepsSound;

    void Update()
    {
        footstepsSound.volume = 0.2f;
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
                footstepsSound.enabled = true;
            }
            else
            {
                footstepsSound.enabled = false;
            }
    }
}