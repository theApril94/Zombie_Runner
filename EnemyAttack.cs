using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] public float damage = 40f;



    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
   

        public void AttackHitEvent()
    {
        if (target == null) return;
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
        Debug.Log("bang bang");
    }

}
