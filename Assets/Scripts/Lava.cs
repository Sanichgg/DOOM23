using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] int damageDeal;
    DamagebleComponent player;
    private void Start()
    {
        StartCoroutine(TakeDamagePerTime());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            player = other.gameObject.GetComponent<DamagebleComponent>();
           
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())  player = null;
    }

    IEnumerator TakeDamagePerTime()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(0.5f);

            if (player != null)
            {
                Debug.Log("f");
                player.Hp -= damageDeal;
            }
        }
    }
}
