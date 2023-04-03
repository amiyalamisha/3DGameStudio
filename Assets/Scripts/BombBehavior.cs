using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float gravity = 9.8f;

    Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.velocity = new Vector3(0, speed * -rb.mass, 0);
    }
}
