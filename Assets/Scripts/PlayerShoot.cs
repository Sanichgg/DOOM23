using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] UIPricel pricel;

    void Update()
    {

        DamagebleComponent damagable 
            = EnemyManager.GetFirstVisibleTarget(transform, 3, Affiliation.Demon | Affiliation.Neutral, 30);

        pricel.CanSoot = damagable != null;
    }
}
