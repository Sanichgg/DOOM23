using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    
    
    
     
    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * 100, Color.green);

        foreach(DamagebleComponent enemy in EnemyManager.Enemies)
        {
            Vector3 enemyDirection = (enemy.transform.position - transform.position);
        }

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit)
            && hit.collider.TryGetComponent(out DamagebleComponent damagable))
        {
            Debug.Log("can damage");
        }
    }
}
