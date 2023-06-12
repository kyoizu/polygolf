using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : ScriptableObject
{
    // Start is called before the first frame update
    public new string name;
    public float cooldownTime;
    public float activeTime;

    public virtual void activate()
    {
        
    }
}
