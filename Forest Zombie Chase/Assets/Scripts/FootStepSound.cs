using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Audio;
using UnityStandardAssets.Characters.FirstPerson;
public class FootStepSound : MonoBehaviour
{
    // Use this for initialization
    AudioSource audioSrc;
    RigidbodyFirstPersonController cc;
    void Start()
    {
        cc = GetComponent<RigidbodyFirstPersonController>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (cc.m_IsGrounded == true && cc.Velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
        {


            GetComponent<AudioSource>().Play();
            // audioSrc.pitch = Random.Range(0.2f, 0.9f);
            // audioSrc.volume = Random.Range(0.1f, 0.8f);
            

        }
    }
}
