using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform cashedCamera;
    void Start()
    {
        cashedCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(cashedCamera.position.x, transform.position.y, cashedCamera.position.z)); ;
    }
}
