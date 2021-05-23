using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenDoorDedector : RunToHeaven
{
    private void OnTriggerEnter(Collider other)
    {
        gameManager.win?.Invoke(); //kanzanma durumu tetiklenir.
    }
    
}
