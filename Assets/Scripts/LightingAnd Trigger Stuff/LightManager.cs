using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightManager : MonoBehaviour
{

    public static LightManager instance;

    public List<Light> lights;

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

    public void SwitchLight(int i)
    {
        lights[i].gameObject.SetActive(!lights[i].gameObject.activeSelf);
    }

    public void SwitchLight(GameObject light)
    {

        light.gameObject.SetActive(!light.activeSelf);

    }

    public void TurnOffLight(int i)
    {
        lights[i].gameObject.SetActive(false);
    }

    public void TurnOffLight(GameObject light)
    {
        light.gameObject.SetActive(false);
    }

    public void TurnOnLight(int i)
    {
        lights[i].gameObject.SetActive(true);
    }

    public void TurnOnLight(GameObject light)
    {
        light.gameObject.SetActive(true);
    }

    public void ChangeLightColor(int ID, Color color) 
    {
    
    }

    public Light FindClosestLight() 
    {

        return null;
    }
}
