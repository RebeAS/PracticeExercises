using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClockSwitch : Interactable
{
    public UnityEvent OnActivation;

    public override void Interact()
    {
        if (OnActivation != null)
        {
            OnActivation.Invoke();
        }
    }
}