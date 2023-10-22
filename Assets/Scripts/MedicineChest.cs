using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    [SerializeField] int heal;
    DamagebleComponent player;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            player.Hp += heal;
            Destroy(this);
        }
    }
}
