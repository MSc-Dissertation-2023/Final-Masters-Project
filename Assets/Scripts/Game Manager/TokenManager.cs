using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public int token { get; private set; }

    // Start is called before the first frame update
    public void Startup()
    {
        Debug.Log("Token Manager starting...");

        status = ManagerStatus.Started;
    }
}
