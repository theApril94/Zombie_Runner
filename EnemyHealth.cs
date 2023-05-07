using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.Processors;
using UnityEngine.SocialPlatforms;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

   public bool IsDead()
    {
        return isDead;
    }
    
   
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(isDead)
        {
            return;
        }

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
