using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRB : MonoBehaviour
{
    public PlayerBehavior playerBehavior;
    [SerializeField] private float deathTime = 6f;

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

            StartCoroutine(WaitReloadScene());
        }
    }

    public IEnumerator WaitReloadScene()
    {
        yield return new WaitForSeconds(deathTime);

        playerBehavior.playerAnimator.SetBool("dead", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);     // reloading current scene

        StopCoroutine(WaitReloadScene());
    }
}
