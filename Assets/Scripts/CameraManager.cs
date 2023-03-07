using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public CinemachineVirtualCamera mainCam;

    public List<CinemachineVirtualCamera> vCams;
    public DetectPlayerCollision[] playerTriggers;

    private string currentCam;

    [SerializeField]
    //private GameObject[] vCams; 

    //singleton
    private void Awake()
    {
        // ANOTHER WAY TO SWITCH CAMERAS
       // vCams[1].Priority = 100;

        if (instance != null && instance != this)
        {
            Destroy(this);

        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void SwitchCamera(string camName1) //string camName2)
    {
        /*
        // make a list of all cameras in scene then make sure they are all off to then activate the right camera
        for(int i = 0; i < camName1.Length; i++)
        {
            if (camName1[i].name != camName1)
            {
                camName1[i].SetActive(false);
            }
        
        }*/


    }

    public void SwitchCameraToMain()
    {
        for(int i = 0; i< vCams.Count; i++)
        {
            if (vCams[i].name != "cam name")
            {
                vCams[i].gameObject.SetActive(false);
            }
            else
            {
                vCams[i].gameObject.SetActive(true);
            }
        }
    }

    public void SwitchLight(int i)
    {
        vCams[i].gameObject.SetActive(!vCams[i].gameObject.activeSelf);
    }

    public void SwitchLight(GameObject light)
    {

        light.gameObject.SetActive(!light.activeSelf);

    }

    public void TurnOffLight(int i)
    {
        vCams[i].gameObject.SetActive(false);
    }

    public void TurnOffLight(GameObject light)
    {
        light.gameObject.SetActive(false);
    }

    public void TurnOnLight(int i)
    {
        vCams[i].gameObject.SetActive(true);
    }

    public void TurnOnLight(GameObject light)
    {
        light.gameObject.SetActive(true);
    }
}
