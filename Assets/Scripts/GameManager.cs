using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;

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
        potionsCollected = 0;
        ChangeCollectedText();
    }

    void Update()
    {
        
    }

    public void ChangeCollectedText()
    {
        score.text = "Antidotes Collected: " + potionsCollected.ToString() + " / 10";
    }
}
