using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] UIPricel pricel;

    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.green);

        foreach(DamagebleComponent enemy in EnemyManager.Enemies)
        {
            Vector3 enemyDirection = (enemy.transform.position - transform.position).normalized;
            
            Vector3 enemyDirection2D = enemyDirection;
            enemyDirection2D.y = 0;
            enemyDirection = enemyDirection2D.normalized;

            enemyDirection = enemyDirection.normalized;

            float angle = Mathf.Acos(Vector3.Dot(transform.forward, enemyDirection)) * Mathf.Rad2Deg;

            if(angle < 3)
            {
                CapsuleCollider enemyCollider = enemy.GetComponent<CapsuleCollider>();

                Vector3 unitFrac = new Vector3(0, enemyCollider.height / 2);

                if (AimLineAttack(enemy.transform.position)
                    || AimLineAttack(enemy.transform.position + unitFrac)
                    || AimLineAttack(enemy.transform.position - unitFrac)) ;

                //RaycastHit hit;

                //raycast
                //if (Physics.Linecast(transform.position, enemy.transform.position, out hit) 
                //    && hit.collider.GetComponent<DamagebleComponent>())
                //{
                //    Debug.DrawLine(transform.position, enemy.transform.position, Color.green);
                //    pricel.CanSoot = true;
                //    return;
                //}

                //if (Physics.Linecast(transform.position, enemy.transform.position + unitFrac, out hit)
                //    && hit.collider.GetComponent<DamagebleComponent>())
                //{
                //    Debug.DrawLine(transform.position, enemy.transform.position + unitFrac, Color.green);
                //    pricel.CanSoot = true;
                //    return;
                //}

                //if (Physics.Linecast(transform.position, enemy.transform.position - unitFrac, out hit)
                //    && hit.collider.GetComponent<DamagebleComponent>())
                //{
                //    Debug.DrawLine(transform.position, enemy.transform.position - unitFrac, Color.green);
                //    pricel.CanSoot = true;
                //    return;
                //}
            }

            pricel.CanSoot = false;
        }
        bool AimLineAttack(Vector3 targetPos)
        {

            if (Physics.Linecast(transform.position, targetPos, out RaycastHit hit)
                    && hit.collider.GetComponent<DamagebleComponent>())
            {
                Debug.DrawLine(transform.position, targetPos, Color.green);
                pricel.CanSoot = true;
                return true;
            }
            return false;
        }


        //if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit)
        //    && hit.collider.TryGetComponent(out DamagebleComponent damagable))
        //{
        //    Debug.Log("can damage");
        //}
    }
}
