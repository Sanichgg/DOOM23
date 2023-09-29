using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagebleComponent : MonoBehaviour
{
    [SerializeField] int hp = 100;

    bool isDead;

    int currentHp;

    private void Start()
    {
        currentHp = hp;
    }

    public bool IsDead => isDead; //property - его нельзя использовать, только прочитать (метод) 
    //ниже запись такая же по функционалу 2
    public bool isAlive
    {
        get
        {
            return !isDead;
        }
    }
    
    public int Hp //property
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

    }

    public void Heal()
    {
        
    }
}
