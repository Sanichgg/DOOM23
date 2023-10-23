using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Elevator : MonoBehaviour
{
    [SerializeField] float speed; //elevator speed
    [SerializeField] int height; //Where to go?
    Vector3 startpos;
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(ElevatorMovement());
        startpos = transform.position;
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
