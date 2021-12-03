using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionComplete : MonoBehaviour
{

    [SerializeField]
    bool showObjective = false;
    [SerializeField]
    Texture objective;
    [SerializeField]
    private int collision;
    [SerializeField] public TextMeshProUGUI missionComplete;

    [SerializeField] Canvas gameOverCanvas;


    private void Awake()
    {
         missionComplete.enabled = false;

         gameOverCanvas.enabled = false;
      

    }

    void Start()
    {

        showObjective = false;

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && showObjective == false && collision == 0)
            showObjective = true;
            Show();
            
            Time.timeScale = 0;

            if(Time.timeScale == 0){
                gameOverCanvas.enabled = true;
                AudioListener.volume = 0;
                FindObjectOfType<WeaponSwitcher>().enabled =false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                

            }
        
    }

    

    void Show(){
        if (showObjective == true )
        {
            missionComplete.enabled = true;
            
        }
    }


    
}
