using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(direction == Vector3.zero)
        {
            return;
        }
        rb.AddForce(direction * force);
    }
}
