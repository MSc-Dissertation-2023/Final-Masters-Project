using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartupEvents : MonoBehaviour
{
    public static event Action ManagersStarted;
    public static event Action<int, int> ManagersProgress;

    public static void NotifyManagersStarted()
    {
        ManagersStarted?.Invoke();
    }

    public static void NotifyProgress(int ready, int modules)
    {
        ManagersProgress?.Invoke(ready, modules);
    }
}
