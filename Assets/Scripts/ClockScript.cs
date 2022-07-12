using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    private int currentHour = 0;
    private int currentMinutes = 0;

    public int TargetHour;
    public int TargetMinutes;

    public System.Action OnSolved;
    public Transform HourHand;
    public Transform MinuteHand;

    public void MoreHours()
    {
        currentHour++;
        if (currentHour > 11)
        {
            currentHour = 0;
        }
        CheckSolution();
        HourHand.Rotate(0, 0, 30);
    }

    public void MoreMinutes()
    {
        currentMinutes += 5;
        if (currentMinutes >= 60)
        {
            currentMinutes = 0;
        }
        CheckSolution();
        MinuteHand.Rotate(0, 0, 30);
    }

    public void CheckSolution()
    {
        if (currentHour == TargetHour && currentMinutes == TargetMinutes)
        {
            if (OnSolved != null)
            {
                OnSolved();
            }
        }
    }
}