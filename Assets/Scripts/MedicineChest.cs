using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    [SerializeField] int heal;
    DamagebleComponent player;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<DamagebleComponent>())
        {
            
            HealPlayer(player);
        }
    }

    void HealPlayer(DamagebleComponent playerStats)
    {
        playerStats.Heal(heal);
        Destroy(gameObject);
    }
}
