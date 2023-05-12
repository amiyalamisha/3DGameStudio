using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject exitTxt;

    public int potionsCollected = 0;
    public InteractableObj interactableExitObj;

    public AudioSource snd_pickup;

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
        exitTxt.SetActive(false);
        //Debug.Log(potionsCollected);
        potionsCollected = 0;
        score.text = "Antidotes Collected: " + potionsCollected.ToString() + " / 4";

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if(potionsCollected > 3)
        {
            exitTxt.SetActive(true);
            interactableExitObj.allowExit = true;
            Debug.Log("all potions collected");
        }
    }

    public void ChangeCollectedText()
    {
        score.text = "Antidotes Collected: " + potionsCollected.ToString() + " / 4";
        snd_pickup.Play();
    }
}
