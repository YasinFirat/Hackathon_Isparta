using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Karakter buraya temas ettiğinde görünmezlik özelliğini kazanabilir.
/// </summary>
public class SecretDedector : RunToHeaven
{
    private void OnTriggerEnter(Collider other)
    {
        gameManager.whenSecretEnter?.Invoke(); //görünmezlik tetiklenir.
    }
    public void OnTriggerExit(Collider other)
    {
        gameManager.whenSecretExit?.Invoke(); //tekrar görünmez olur.
    }
}
