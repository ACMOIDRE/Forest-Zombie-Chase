using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Mission : MonoBehaviour
{
    [SerializeField]
    bool showObjective = false;
    [SerializeField]
    Texture objective;
    [SerializeField]
    private int collision;
    
    [SerializeField] public TextMeshProUGUI missionTitle;


    private void Awake()
    {
         missionTitle.enabled = false;
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
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            showObjective = false;
        collision = 1;
        NoShow();
    }
    

    void Show(){
        if (showObjective == true )
        {
            missionTitle.enabled = true;
            
        }
    }

    void NoShow(){
        if (showObjective == false )
        {
            // // TextMeshPro missionTitle = GetComponent<TextMeshPro>();
            missionTitle.enabled = false;
            
        }
    }

    void Update()
    {
        if (Input.GetButton("ShowObj") && collision == 1)
        {
            showObjective = true;
        }
        if (Input.GetButtonUp("ShowObj") && collision == 1)
        {
            showObjective = false;
        }
    }

    // void OnGUI()
    // {
    //     if (showObjective == true)
    //         GUI.DrawTexture(new Rect(Screen.width / 1.5f, Screen.height / 1.4f, 178, 178), objective);
    //         GUI.Label(new Rect(10, 220, 100, 20), "Hello World!");



    // }
}
