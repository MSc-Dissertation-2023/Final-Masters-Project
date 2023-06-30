using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static event Action EnemyKilled;
    public static event Action GamePaused;
    public static event Action GameUnpaused;
    public static event Action<float> UpdateHealth;
    public static event Action<int> UpdateAmmo;
    public static event Action GameEnd;
    public static event Action<float> SensitivityChanged;


    public static void NotifyDeath()
    {
        EnemyKilled?.Invoke();
    }

    public static void NotifyPaused()
    {
        GamePaused?.Invoke();
    }

    public static void NotifyUnpaused()
    {
        GameUnpaused?.Invoke();
    }

    public static void NotifyEnd()
    {
        GameEnd?.Invoke();
    }

    public static void NotifyHealth(float health) 
    {
        UpdateHealth?.Invoke(health);
    }

    public static void NotifyAmmo(int ammo) 
    { 
        UpdateAmmo?.Invoke(ammo);
    }

    public static void ChangeSensitivity(float sensitivity)
    {
        SensitivityChanged?.Invoke(sensitivity);
    }


}
