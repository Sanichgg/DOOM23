using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Elevator : MonoBehaviour
{
    [SerializeField] float speed; 
    [SerializeField] int height; 
    Vector3 startpos;
    Transform passenger;

    private void Start()
    {
        startpos = transform.position;
        StartCoroutine(ElevatorMovement());
        
    }
    IEnumerator ElevatorMovement()
    {
        float t = 0;
        while (true)
        {
            while (t < 1)
            {
                transform.position = Vector3.Lerp(startpos, startpos + Vector3.up * height, t);
                t += speed / 1000;
                yield return null;
            }
            yield return new WaitForSeconds(2f);
            while (t > 0)
            {
                transform.position = Vector3.Lerp(startpos, startpos + Vector3.up * height, t);
                t -= speed / 1000;
                yield return null;
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
