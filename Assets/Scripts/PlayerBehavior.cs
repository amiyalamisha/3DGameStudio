using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject fakeRB;
    private GameManager gameManager;
    public Animator playerAnimator;
    private ThirdPersonController thirdPersonController;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        gameManager = GameManager.instance;
    }

    void Update()
    {
        if (playerAnimator.GetBool("dead"))
        {
            thirdPersonController.enabled = false;
        }
        else
        {
            thirdPersonController.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "potion")
        {
            gameManager.potionsCollected++;
            Debug.Log(gameManager.potionsCollected);

            Destroy(other.gameObject);      // smoke effect here
        }
    }

    public void Death()
    {
        
    }

    
}
