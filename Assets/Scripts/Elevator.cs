using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Elevator : MonoBehaviour
{
    [SerializeField] float speed; //elevator speed
    [SerializeField] int height; //Where to go?
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        MoveElevator();
    }
    public void MoveElevator()
    {

    }
}
