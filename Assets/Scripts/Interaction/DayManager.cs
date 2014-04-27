﻿using UnityEngine;
using System.Collections;

public class DayManager : MonoBehaviour {
    public static int currentDay = 1;

    public static void GotoNextDay()
    {
        currentDay++;
        Application.LoadLevel("day" + currentDay);
    }
}