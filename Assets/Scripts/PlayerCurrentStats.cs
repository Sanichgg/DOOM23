using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrentStats : MonoBehaviour
{
    [SerializeField] int health = 100;
    int curretHealth;
    void Start()
    {
        health = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0) { gameObject.GetComponent<PlayerController>().killPlayer(); }
    }
    public void DamageTake (int Damage)
    {
        health -= Damage; 
    }
    public void Heal(int Healing)
    {

    }
}
