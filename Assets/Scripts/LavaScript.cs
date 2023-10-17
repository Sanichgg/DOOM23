using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    [SerializeField] int damageDeal;

    public void OnCollisionEnter(Collision collision)
    {
        
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<DamagebleComponent>()) StopAllCoroutines();
    }

    IEnumerator TakeDamagePerTime(int damage, DamagebleComponent damagable)
    {
        while (true)
        {
            damagable.DealDamage(damage);
            yield return new WaitForSeconds(1f);
        }
    }


    void OnCharacterStay(PlayerController controller)
    {
        print($"Lava Player stay: {controller.name}");
    }
    void OnCharacterEnter()
    {
        print("Lava Player enter");
        //DamagebleComponent damagable = collision.gameObject.GetComponent<DamagebleComponent>();
        /*
        if (damagable != null)
        {
            StartCoroutine(TakeDamagePerTime(damageDeal, damagable));
        }
        */
    }
    void OnCharacterExit()
    {
        print("Lava Player exit");
        //if (collision.gameObject.GetComponent<DamagebleComponent>()) StopAllCoroutines(); // ДЗ: ПЕРЕПИСАТЬ лифты и лаву ПОД message-систему

    }
}
