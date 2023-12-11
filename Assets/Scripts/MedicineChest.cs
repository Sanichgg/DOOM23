using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    [SerializeField] int heal;
    DamagebleComponent damagableComponent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<DamagebleComponent>(out DamagebleComponent hinge))
        {
            damagableComponent = other.gameObject.GetComponent<DamagebleComponent>();
            damagableComponent.Hp += heal;
            Debug.Log($"{damagableComponent.Hp} current HP");
            Destroy(gameObject);
        }
    }
}
