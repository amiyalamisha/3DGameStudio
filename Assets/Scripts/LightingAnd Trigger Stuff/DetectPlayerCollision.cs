using System;
using UnityEngine;
using Random = UnityEngine.Random;
//using UnityEngine = UnityEngine.Random;



public class DetectPlayerCollision : MonoBehaviour
{
    public event Action<string> playerEnter = delegate { };
    public event Action<string> playerExit = delegate { };

    private TriggerManager triggerManager;

    public GameObject Player;
    public CharacterController PlayerCharacter;

    [SerializeField]
    private GameObject flowerBomb;
    [SerializeField]
    private float bombObjScale = 5f;

    [SerializeField]
    private Transform objSpawn;
    //public GameObject assignedLight;
    //public int assignedLightID;

    public GameObject assignedTrap;
    public int assignedTrapID;
    [SerializeField]
    private bool trapOff = false;
    [SerializeField]
    private bool trapExplosion = false;
    [SerializeField]
    private bool trapShoot = false;
    [SerializeField]
    private bool shootLeft = false;

    public string vCamToSwitch;


    void Start()
    {
        triggerManager = TriggerManager.instance;
    }

    public void Awake()
    {
        //Player = FindObjectOfType<PlayerCharacterLogic>().gameObject;
        Player = this.gameObject;
        PlayerCharacter.GetComponent<CharacterController>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCharacter)
        {   
            if (assignedTrap && trapExplosion && !trapOff)
            {
                float randSpawn = Random.Range(5.0f, 9.0f);
                for (int i = 0; i < randSpawn; i++)
                {
                    //triggerManager.FlowerBomb();
                    GameObject bombObj = Instantiate(flowerBomb, transform.position, Quaternion.identity, transform);
                    Rigidbody rb = bombObj.GetComponent<Rigidbody>();
                    bombObj.transform.localScale = new Vector3(bombObjScale, bombObjScale, bombObjScale);     // setting scale of new spawned objects

                    // so all the objects don't tilt the same way
                    Vector3 explosionDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
                    rb.AddForce(explosionDirection.normalized * 10f, ForceMode.Impulse);        // adding force to obj not velocity
                }

                trapOff = true;
            }

            if(assignedTrap && trapShoot && !trapOff)
            {
                float randSpawn = Random.Range(5.0f, 9.0f);         // number of flowers spawning
                for (int i = 0; i < randSpawn; i++)
                {
                    Quaternion spawnAngle = Quaternion.Euler(90f, 90f, 0f);     // setting defined spawn rotation
                    //Vector3 spawnPos = new Vector3(flowerBomb.transform.position.x, flowerBomb.transform.position.y);
                    Vector3 spawnPos;
                    if (shootLeft)
                    {
                        spawnPos = new Vector3(objSpawn.transform.position.x, objSpawn.transform.position.y, objSpawn.transform.position.z);
                    }
                    else
                    {
                        spawnPos = new Vector3(objSpawn.transform.position.x + .5f, objSpawn.transform.position.y, objSpawn.transform.position.z);
                    }
                    

                    GameObject bombObj = Instantiate(flowerBomb, spawnPos, spawnAngle, transform);
                    Rigidbody rb = bombObj.GetComponent<Rigidbody>();
                    bombObj.transform.localScale = new Vector3(bombObjScale, bombObjScale, bombObjScale);     // setting scale of new spawned objects
                    Debug.Log("bomb");
                    // so all the objects don't tilt the same way
                    //Vector3 explosionDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
                    if (shootLeft)
                    {
                        rb.AddForce(Vector3.left * 8f, ForceMode.Impulse);        // adding force to obj not velocity
                    }
                    else
                    {
                        rb.AddForce(Vector3.right * 5f, ForceMode.Impulse);        // adding force to obj not velocity
                    }
                    
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
        if (other == PlayerCharacter)
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
        if (other == PlayerCharacter)
        {
          //  Debug.Log("Trigger Stay");
        }
    }


}
