using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    [SerializeField] int damageDeal;
    DamagebleComponent player;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = FindObjectOfType<DamagebleComponent>();
            StartCoroutine(TakeDamagePerTime(damageDeal, player));
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player") StopAllCoroutines();
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
