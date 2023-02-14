using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    public int[] values = new int [5];
    public int[] valuesExample2 = { 12, 76, 8, 937, 903 };


    public static TriggerManager instance;
    public List<TriggerAction> TriggersInScene;


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
            Ta.TriggerObject.assignedLight = Ta.light.gameObject;

            Ta.TriggerObject.playerEnter += TriggerObservation;
            Ta.TriggerObject.playerExit += TriggerObservation;
        }
    }

    
    public void TriggerObservation(string message) 
    {
        Debug.Log(message);
        Debug.Log("Observeration worked");
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
