using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine = System.Random;

public class RandomTrapClusters : MonoBehaviour
{
    public List<GameObject> trapList;
    public int numTrapsEnabled;

    private void Start()
    {
        // Enable a random object from the list
        if (trapList.Count > 0)
        {
            for(int i = 0; i < trapList.Count; i++)
            {
                trapList[i].SetActive(false);
            }

            for(int i = 0; i < numTrapsEnabled; i++)
            {
                int randomIndex = Random.Range(0, trapList.Count);
                Debug.Log(randomIndex);
                //GameObject randomObject = trapList[randomIndex];
                trapList[randomIndex].SetActive(true);
            }
        }
    }
}
