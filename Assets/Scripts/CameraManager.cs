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

    [SerializeField]
    //private GameObject[] vCams; 

    //singleton
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

        DontDestroyOnLoad(this.gameObject);
    }

    public void SwitchCamera(string camName)
    {

        /*
        for(int i = 0; i < camName.Length; i++)
        {
            if (camName[i].name != camName)
            {
                camName[i].SetActive(false);
            }
        }*/
    }

    public void SwitchCameraToMain()
    {
        for(int i = 0; i< vCams.Length; i++)
        {
            if (vCams[i].name != "cam name")
            {
                vCams[i].SetActive(false);
            }
            else
            {
                vCams[i].SetActive(true);
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
