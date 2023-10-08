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

            currentHp = value;
            if(currentHp <= 0)
            {
                Die();
            }
        }
    } 

    void Die()
    {
        Debug.Log($"{gameObject.name} is dead");
        isDead = true;
    }

    public void DealDamage(int damageAmount)
    {
        currentHp -= damageAmount;
    }

    public void Heal(int healAmount)
    {
        currentHp += healAmount;
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
