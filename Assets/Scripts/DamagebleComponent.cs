using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagebleComponent : MonoBehaviour
{
    [SerializeField] protected int maxHP;
    [SerializeField] protected Affiliation affiliation;

    public Affiliation Affiliation => affiliation;

    protected bool isDead;
    protected int currentHp;

    private void Start() => currentHp = maxHP;

    private void OnEnable()
    {
        EnemyManager.RegisterEnemy(this);
    }

    private void OnDisable()
    {
        EnemyManager.UnregisterEnemy(this);
    }

    public bool IsDead => isDead;
    public bool IsAlive => !isDead;

    public int Hp
    {
        get => currentHp;
        set
        {
            if (isDead) return;

            currentHp = value;

            if (currentHp <= 0)
            {
                currentHp = 0;
                Die();
            }
        }
    }

    public virtual void DealDamage(int damageAmount)
    {
        Hp -= damageAmount;
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} is died from cringe");
    }

    public virtual bool TryHeal(int amountToHeal)
    {
        if (currentHp < maxHP)
        {
            currentHp += Mathf.Clamp(amountToHeal, 0, maxHP - currentHp);
            return true;
        }
        else
        {
            return false;
        }
    }
}
