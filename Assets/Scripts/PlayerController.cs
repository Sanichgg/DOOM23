using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 1;
    [SerializeField] float sideSpedd = 1;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.AddForce (new Vector3(horizontal * Time.fixedDeltaTime * sideSpedd, 
            0,
            vertical * Time.fixedDeltaTime * forwardSpeed));
    }

    public void killPlayer()
    {
        Destroy(gameObject);
    }
}
