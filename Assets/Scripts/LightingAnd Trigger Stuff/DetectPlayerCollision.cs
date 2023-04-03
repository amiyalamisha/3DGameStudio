using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DetectPlayerCollision : MonoBehaviour
{
    private TriggerManager triggerManager;

    public GameObject Player;
    public CharacterController PlayerCollisionObject;

    //public GameObject assignedLight;
    //public int assignedLightID;

    public GameObject assignedTrap;
    public int assignedTrapID;

    public string vCamToSwitch;

    public event Action<string> playerEnter = delegate { };
    public event Action<string> playerExit = delegate { };

    void Start()
    {
        triggerManager = TriggerManager.instance;
    }

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
            if (assignedTrap)
            {
                triggerManager.FlowerBomb();
            }
            /*
            if (assignedLight)
            {
                LightManager.instance.TurnOnLight(assignedLight);
            }
            else { 
                LightManager.instance.TurnOnLight(assignedLightID); 
                Debug.Log("use ID"); 
            }*/
        }



        playerEnter?.Invoke("Something");

        if(vCamToSwitch != "" && vCamToSwitch == "CM vcam1")
        {
            Debug.Log("cam swtich");

            CameraManager.instance.SwitchCamera(vCamToSwitch);
        }
        else if(vCamToSwitch != "" && vCamToSwitch == "CM vcam1")
        {
            CameraManager.instance.SwitchCameraToMain();
        }

    }
    


    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollisionObject)
        {
            /*
            if (assignedLight) 
            { 
                LightManager.instance.TurnOffLight(assignedLight); 
            }
            else
            { 
                LightManager.instance.TurnOffLight(assignedLightID); 
            }*/


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
