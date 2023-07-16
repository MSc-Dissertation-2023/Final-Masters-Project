using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class MazeEvents : MonoBehaviour
{
    
    public static event Action ObjectiveReached;


    public static void NotifyObjectiveReached()
    {
        ObjectiveReached?.Invoke();
    }
}

[System.Serializable]
public class SendCodeEvent : UnityEvent<string> { };

[System.Serializable]
public class GetCodeEvent : UnityEvent { };

[System.Serializable]
public class BuildOuterWallsEvent : UnityEvent { };

[System.Serializable]
public class SpawnPrefabsEvent : UnityEvent { };

[System.Serializable]
public class RequestMazeSizesEvent : UnityEvent { };

[System.Serializable]
public class PublishMazeSizesEvent : UnityEvent<int, int> { };

