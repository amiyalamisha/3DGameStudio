using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DetectPlayerCollision : MonoBehaviour
{

    public event Action<string> playerEnter =   delegate { };
    public event Action<string> playerExit = delegate { };


    public GameObject Player;
    public CharacterController PlayerCollisionObject;

    public GameObject assignedLight;
    public int assignedLightID;



    public void Awake()
    {
        //Player = FindObjectOfType<PlayerCharacterLogic>().gameObject;
        Player = this.gameObject;
        PlayerCollisionObject.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCollisionObject)
        {

            if (assignedLight)
            {
                LightManager.instance.TurnOnLight(assignedLight);
            }
            else { LightManager.instance.TurnOnLight(assignedLightID); Debug.Log("use ID"); }

        }



            playerEnter?.Invoke("Something");


    }
    


    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollisionObject)
        {

          if (assignedLight) 
            { 
                LightManager.instance.TurnOffLight(assignedLight); 
            }
          else{ LightManager.instance.TurnOffLight(assignedLightID); }


            playerExit?.Invoke(null);


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == PlayerCollisionObject)
        {
          //  Debug.Log("Trigger Stay");
        }
    }


}
