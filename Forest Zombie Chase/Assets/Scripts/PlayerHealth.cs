using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float hitPoints = 100f;
    [SerializeField] public float maxPoints = 100f;
    // public float healthBonus = 50f;
    [SerializeField] float damage = 20f;
    [SerializeField] public Image healthImage;

    private void Update() {
        UpdateHealth();
        
    }


    public void TakeDamage(float damage)
    {
        hitPoints -= damage;

        UpdateHealth();

        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();

        }

    }

    private void UpdateHealth()
    {
        healthImage.fillAmount = hitPoints / maxPoints;
       
    }


    public void RestoreHealth( )
    {
        
        hitPoints = 100f;
        // Debug.Log("health call ");

    }

}
