using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // when touching a dangerous obj game restarts
        if(collision.gameObject.tag == "dangerObj")
        {
            Debug.Log("danger");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);     // reloading current scene
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
}
