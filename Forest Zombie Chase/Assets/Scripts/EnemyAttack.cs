using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 30f;
    PlayerHealth target;

    AudioSource audioData;
    
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();

        audioData = GetComponent<AudioSource>();
               
    }

    public void AttackHitEvent(){
        if (target == null) return;
        
        target.TakeDamage(damage);
        target.GetComponent<DamageScreen>().ShowDamageImpact();

        audioData.Play(0);
        
    }

}
