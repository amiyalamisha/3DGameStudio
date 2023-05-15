using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRB : MonoBehaviour
{
    public PlayerBehavior playerBehavior;

    public AudioSource snd_death;
    //[SerializeField] private float deathTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        //playerBehavior = GetComponent<PlayerBehavior>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // when touching a dangerous obj game restarts
        if (other.gameObject.tag == "dangerObj")
        {
            playerBehavior.playerAnimator.SetBool("dead", true);

            StartCoroutine(WaitReloadScene(4f));
        }
        if (other.gameObject.tag == "exit")
        {
            playerBehavior.playerAnimator.SetBool("win", true);

            StartCoroutine(WaitReloadScene(3f));
        }
    }

    public IEnumerator WaitReloadScene(float waitTime)
    {
        if (playerBehavior.playerAnimator.GetBool("dead"))
        {
            snd_death.PlayDelayed(0.5f);
        }

        yield return new WaitForSeconds(waitTime);
        
        

        playerBehavior.playerAnimator.SetBool("dead", false);
        playerBehavior.playerAnimator.SetBool("win", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);     // reloading current scene

        StopCoroutine(WaitReloadScene(waitTime));
    }
}
