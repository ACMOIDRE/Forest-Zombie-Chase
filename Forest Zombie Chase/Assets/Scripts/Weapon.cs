using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 0.5f;

    bool canShoot = true;
    [SerializeField] TextMeshProUGUI ammoText;

    AudioSource audioData;
    
    private void Start() {
        
        audioData = GetComponentInParent<AudioSource>();
    }
    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
                                                       
        }

        DisplayAmmo();
    }

    private void DisplayAmmo()
    {
        int CurrentAmmo =  ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = CurrentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ProcessRayCast();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
            audioData.Play(1);              
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
        
        
    }

    private void ProcessRayCast()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
            

        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        
        Destroy(impact, 0.1f);
    }
}
