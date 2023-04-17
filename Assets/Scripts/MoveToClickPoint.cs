using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;

    public Animator ani;

    public float speed;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Cursor.lockState = CursorLockMode.Confined;

        ani.applyRootMotion = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
                
            }
        }





    }


    private void FixedUpdate()
    {

       // speed = GetComponent<NavMeshAgent>().velocity.magnitude;

      //  ani.SetFloat("Speed",speed);
           
      //  print(speed);
    }

  
}
