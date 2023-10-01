using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    [SerializeField]int damageDeal;
    
    PlayerCurrentStats player;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = FindObjectOfType<PlayerCurrentStats>();
            StartCoroutine(TakeDamagePerTime(damageDeal, player));
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player") StopAllCoroutines();
    }

    IEnumerator TakeDamagePerTime(int damage, PlayerCurrentStats playerStats)
    {
        while (true)
        {
            playerStats.DamageTake(damage);
            yield return new WaitForSeconds(1f);
        }
    }
}
