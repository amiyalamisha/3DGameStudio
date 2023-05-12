using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerTxt;

    public float currentTime = 0f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.interactableExitObj.allowExit)
        {
            currentTime = currentTime + Time.deltaTime;
            timerTxt.text = "Timer: " + currentTime.ToString("0.00");
        }
        
    }
}
