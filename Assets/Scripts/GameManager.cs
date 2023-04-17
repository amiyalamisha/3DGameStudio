using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int potionsCollected = 0;

    public static GameManager instance;

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

    void Start()
    {
        Debug.Log(potionsCollected);
    }

    void Update()
    {
        
    }
}
