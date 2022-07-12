using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeightSwitch : MonoBehaviour
{
    public UnityEvent OnActivation;
    public UnityEvent OnDeactivation;

    private float currentMass = 0;
    private float targetMass = 5;

    private Rigidbody collidingObject;

    private void OnCollisionEnter(Collision collision)
    {
        collidingObject = collision.gameObject.GetComponent<Rigidbody>();
        if (collidingObject != null)
        {
            currentMass += collidingObject.mass;
            CheckMass();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collidingObject = collision.gameObject.GetComponent<Rigidbody>();
        if (collidingObject != null)
        {
            currentMass -= collidingObject.mass;
            CheckMass();
        }
    }

    public void CheckMass()
    {
        if (currentMass >= targetMass)
        {
            if (OnActivation != null)
            {
                OnActivation.Invoke();
            }
        }
        else
        {
            if (OnDeactivation != null)
            {
                OnDeactivation.Invoke();
            }
        }
    }
}