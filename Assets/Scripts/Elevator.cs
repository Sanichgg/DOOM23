using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Elevator : MonoBehaviour
{
    [SerializeField] float speed; //elevator speed
    [SerializeField] int height; //�� ���� �����������???
    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        MoveElevator();
    }
    public void MoveElevator()
    {

    }
}
