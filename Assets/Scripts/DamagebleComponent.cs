using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagebleComponent : MonoBehaviour
{
    [SerializeField] int hp = 100;

    bool isDead;

    [SerializeField] int currentHp;

    private void Start()
    {
        currentHp = hp;
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
            if (isDead) return;

            if (currentHp == 100)
                return;

            currentHp = value;

            if (currentHp <= 0)
            {
                Die();
            }
            if (currentHp > 100)
            {
                currentHp = hp;
            }
        }
    }
    private void Update()
    {
        
        Debug.Log(currentHp);
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
