using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] int damageDeal;
    DamagebleComponent player;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<DamagebleComponent>())
        {
            player = collision.gameObject.GetComponent<DamagebleComponent>();
            StartCoroutine(TakeDamagePerTime(damageDeal, player));
            
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<DamagebleComponent>())
            player = collision.gameObject.GetComponent<DamagebleComponent>();
        StopAllCoroutines();
    }

    IEnumerator TakeDamagePerTime(int damage, DamagebleComponent playerStats)
    {
        
        while (true)
        {
            playerStats.DealDamage(damage);
            yield return new WaitForSeconds(1f);
        }
    }
}
