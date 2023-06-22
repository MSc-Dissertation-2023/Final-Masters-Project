using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}
    // Start is called before the first frame update
    public void Startup()
    {
        Debug.Log("Inventory amanger starting...");
        status = ManagerStatus.Started;
    }
}
