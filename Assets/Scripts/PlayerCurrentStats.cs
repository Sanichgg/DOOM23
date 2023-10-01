using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrentStats : MonoBehaviour
{
    public int health = 0;
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (health<=0) { gameObject.GetComponent<PlayerController>().killPlayer(); }
    }
    
}
