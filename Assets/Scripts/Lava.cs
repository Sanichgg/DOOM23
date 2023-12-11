using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] int damageDeal;
    IEnumerator TakeDamagePerTime;

    IEnumerator ContiniousDamage(DamagebleComponent damagableComponent)
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            damagableComponent.Hp -= damageDeal;
            Debug.Log($"{damagableComponent.gameObject.name} {damagableComponent.Hp} current HP");
        }
    }

    void OnCharacterExit()
    {
        StopCoroutine(TakeDamagePerTime);
    }

    void OnCharacterEnter(BaceCharacterController controller)
    {
        StartCoroutine(TakeDamagePerTime = ContiniousDamage(controller.gameObject.GetComponent<DamagebleComponent>()));
    }
}
