using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    public int[] values = new int [5];
    public int[] valuesExample2 = { 12, 76, 8, 937, 903 };


    public static TriggerManager instance;
    public List<TriggerAction> TriggersInScene;

    public GameObject flowers;
    public Rigidbody bodyProjectile;
    public Transform startPos;
    [SerializeField]
    private float expObjNum = 3f;


    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this);

        }
        else
        {
            instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {




        foreach (TriggerAction Ta in TriggersInScene)
        {
            //Ta.TriggerObject.assignedLight = Ta.light.gameObject;
            Ta.TriggerObject.assignedTrap = Ta.bomb.gameObject;

            Ta.TriggerObject.playerEnter += TriggerObservation;
            Ta.TriggerObject.playerExit += TriggerObservation;
        }
    }

    void Update()
    {
        
    }
    
    public void TriggerObservation(string message) 
    {
        //Debug.Log(message);
        Debug.Log("Observeration worked");
    
    }

    public void FlowerBomb()
    {
        for(int i = 0 ; i < expObjNum; i++)
        {
            GameObject newFlowers = Instantiate(flowers, startPos.position, Quaternion.identity);
            //newFlowers.transform.position = new Vector3(0, 5f * -1 * Time.deltaTime, 0);


            Debug.Log("flowerbomb");
        }

    }
}
