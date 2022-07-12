using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private Light MyLight;
    private ClockScript clockScript;

    private void Start()
    {
        clockScript = FindObjectOfType<ClockScript>();
        clockScript.OnSolved += Activate;

        MyLight = gameObject.GetComponent<Light>();
        MyLight.enabled = false;
    }

    public void Activate()
    {
        MyLight.enabled = true;
    }
}