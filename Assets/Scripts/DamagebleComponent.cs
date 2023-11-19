using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagebleComponent : MonoBehaviour
{
    [SerializeField] int maxHp = 100;
    [SerializeField] Affiliation affiliation;

    public Affiliation Affiliation => affiliation;


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
        get => currentHp;
        set
        {
            Debug.Log(value);
            if (isDead) return;

            if (value <= 0)
            {
                currentHp = value;
                Die();
            }

            else if (value > 100)
            {
                currentHp = maxHp;
            }
            else
            {
                currentHp = value;
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
