using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI exitTxt;

    public int potionsCollected = 0;

    public static GameManager instance;

    public InteractableObj interactableExitObj;

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
        exitTxt.enabled = false;
        //Debug.Log(potionsCollected);
        potionsCollected = 0;
        ChangeCollectedText();
    }

    void Update()
    {
        if(potionsCollected == 4)
        {
            exitTxt.enabled = true;
            interactableExitObj.allowExit = true;
        }
    }

    public void ChangeCollectedText()
    {
        score.text = "Antidotes Collected: " + potionsCollected.ToString() + " / 4";
    }
}
