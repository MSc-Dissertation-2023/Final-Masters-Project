using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MazeEvents : MonoBehaviour
{
    public static event Action<string> SendCode;
    public static event Action GetCode;
    public static event Action ObjectiveReached;

    public static void NotifyCode(string code)
    {
        SendCode?.Invoke(code);
    }

    public static void RequestCode()
    {
        GetCode?.Invoke();
    }

    public static void NotifyObjectiveReached()
    {
        ObjectiveReached?.Invoke();
    }
}
