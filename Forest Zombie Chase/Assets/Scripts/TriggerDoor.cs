using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private Animator myDoor;


    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("enter  trigger");

        if (other.CompareTag("Player"))
        {
            if (myDoor.gameObject.activeSelf)
            {
                myDoor.Play("DoorOpen");
                myDoor.SetBool("open_close", true);

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        // Debug.Log("exit trigger");

        if (other.CompareTag("Player"))
        {
            if (myDoor.gameObject.activeSelf)
            {
                myDoor.Play("DoorClose");
                myDoor.SetBool("open_close", false);

            }

        }
    }

    
    // [SerializeField] private bool openTrigger = false;
    // [SerializeField] private bool closeTrigger = false;

    // private void OnTriggerEnter(Collider other)
    // {

    //     if (other.CompareTag("Player"))
    //     {
    //         if (openTrigger)
    //         {
    //             game obj is openTrigger
    //             myDoor.Play("DoorOpen", 0, 0.0f);
                
    //             gameObject.SetActive(false);
    //             Debug.Log("Open door" +" " +  gameObject);
    //         }
    //         else if (closeTrigger)
    //         {
    //             myDoor.Play("DoorClose", 0, 0.0f);
    //             gameObject.SetActive(false);
    //             Debug.Log("close door");
    //         }
    //     }

    // }

}
