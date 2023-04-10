using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
//using UnityEngine = UnityEngine.Random;



public class DetectPlayerCollision : MonoBehaviour
{
    private TriggerManager triggerManager;

    public GameObject Player;
    public CharacterController PlayerCollisionObject;

    [SerializeField]
    private GameObject flowerBomb;

    //public GameObject assignedLight;
    //public int assignedLightID;

    public GameObject assignedTrap;
    public int assignedTrapID;
    private bool trapOff = false;

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

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCollisionObject)
        {
            if (assignedTrap && !trapOff)
            {
                for(int i = 0; i < 5; i++)
                {
                    //triggerManager.FlowerBomb();
                    GameObject newObject = Instantiate(flowerBomb, transform.position, Quaternion.identity, transform);
                    Rigidbody rb = newObject.GetComponent<Rigidbody>();

                    // so all the objects don't tilt the same way
                    Vector3 explosionDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
                    rb.AddForce(explosionDirection.normalized * 10f, ForceMode.Impulse);        // adding force to obj not velocity
                }

                trapOff = true;
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
