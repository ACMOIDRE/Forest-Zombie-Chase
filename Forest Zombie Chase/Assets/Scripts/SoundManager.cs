using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static AudioClip idleEnemySound, chaseEnemySound, attackEnemySound, bulletHit, playerWalk, playerRun;
    static AudioSource audioScr;

    void Start()
    {
        audioScr = GetComponent<AudioSource>();

        // enemy
        idleEnemySound = Resources.Load<AudioClip>("enemyIdle");
        // chaseEnemySound = Resources.Load<AudioClip>("enemyChase");
        attackEnemySound = Resources.Load<AudioClip>("enemyAttack");

        // player
        bulletHit = Resources.Load<AudioClip>("GunShot");
        playerWalk = Resources.Load<AudioClip>("Walk");
        playerRun = Resources.Load<AudioClip>("Run1");
    }

    //SoundManager.PlaySound("GunShot");  // use in function animation or function
    //SoundManager.PlaySound("enemyAttack");

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "idleEnemy" :
                audioScr.PlayOneShot(idleEnemySound);
            break;
            // case "chaseEnemy" :
            //     audioScr.PlayOneShot(chaseEnemySound);
            // break;
            case "enemyAttack" :
                audioScr.PlayOneShot(attackEnemySound);
            break;
            case "GunShot" :
                audioScr.PlayOneShot(bulletHit);
            break;
            case "Walk" :
                audioScr.PlayOneShot(playerWalk);
            break;
            case "Run1" :
                audioScr.PlayOneShot(playerRun);
            break;
        }
    }


}
