using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    // floating and spinning a safe object
    [SerializeField] private float floatHeight = 1f; // The height the object will float
    [SerializeField] private float floatSpeed = 0.5f; // The speed at which the object will float
    [SerializeField] private float spinSpeed = 10f; // The speed at which the object will spin

    public bool exit;
    public bool allowExit;

    private Vector3 startPos; // The starting position of the object

    private void Start()
    {
        startPos = transform.position; // Store the starting position of the object
    }

    private void Update()
    {

        if(allowExit || !exit)
        {
            // Float the object up and down
            Vector3 pos = startPos;
            pos.y += Mathf.Sin(Time.time * floatSpeed) * floatHeight;
            transform.position = pos;

            // Spin the object
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
        
    }
}
