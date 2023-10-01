using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float forwardForse = 1;
    [SerializeField] float sideForse = 1;
    [SerializeField] float sensativity;


    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float xMouseMovement = Input.GetAxis("Mouse X");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forse = Vector3.zero;
        
        forse += transform.forward * vertical * Time.fixedDeltaTime * forwardForse;
        forse += transform.right * horizontal * Time.fixedDeltaTime * sideForse;

        float rotation = xMouseMovement * sensativity * Time.fixedDeltaTime;

        rb.AddForce(forse);
        transform.Rotate(0, rotation, 0);

    }
}
