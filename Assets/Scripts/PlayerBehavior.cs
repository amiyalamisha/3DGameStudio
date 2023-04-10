using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    void Start()
    {
        
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
}
