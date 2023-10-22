using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] int damageDeal;
    DamagebleComponent player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            player = other.gameObject.GetComponent<DamagebleComponent>();
            StartCoroutine(TakeDamagePerTime(damageDeal, player));
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
            player = other.gameObject.GetComponent<DamagebleComponent>();
        StopAllCoroutines();
    }

    IEnumerator TakeDamagePerTime(int damage, DamagebleComponent playerStats)
    {
        while (true)
        {
            Debug.Log("f");
            yield return new WaitForSeconds(0.5f);
            playerStats.Hp -= damage;
        }
    }
}
