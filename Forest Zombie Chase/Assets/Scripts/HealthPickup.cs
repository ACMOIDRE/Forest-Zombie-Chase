using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;
    public float healthBonus = 20f ;
    private void Awake() {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
            Debug.Log(playerHealth.hitPoints +"--" + playerHealth.maxPoints );
            // playerHealth.hitPoints = playerHealth.hitPoints + healthBonus;
            playerHealth.RestoreHealth();
            Debug.Log(playerHealth.hitPoints );
            Destroy(this.gameObject);
        

    }

}
