using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagebleComponent : MonoBehaviour
{
    [SerializeField] int maxHp = 100;
    int hp;

    bool isDead;

    [SerializeField] int currentHp;

    private void Start()
    {
        Hp = maxHp;
    }

    public bool IsDead => isDead; 
    public bool isAlive
    {
        get
        {
            return !isDead;
        }
    }
    
    public int Hp 
    {
        get => hp;
        set
        {
            Debug.Log(value);
            if (isDead) return;

            if (value <= 0)
            {
                hp = value;
                Die();
            }
            
            else if (value > 100)
            {
               hp = maxHp;
            }
            else
            {
                hp = value;
            }

        }
    }
    private void Update()
    {
        
        //Debug.Log(currentHp);
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} is dead");
        isDead = true;
    }


    private void OnEnable()
    {
        EnemyManager.RegisterEnemy(this);
    }
    private void OnDisable()
    {
        EnemyManager.UnregisterEnemy(this);
    }
}
