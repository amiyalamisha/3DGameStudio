using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerType {Light,Audio }

[System.Serializable]
public class TriggerAction
{

    public DetectPlayerCollision TriggerObject;
    public Light light;


}
