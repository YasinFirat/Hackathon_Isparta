using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyRadar : RunToHeaven
{
    [Tooltip("Player ile temas ettiğinde yapılacaklar seçilir.")]
    
    public UnityEvent whenEnter;

    public void OnTriggerEnter(Collider other)
    {
        //eğer player gizlendiyse return yap yani aşağıdaki kodları çalıştırma.
        if (gameManager.isPlayerVisible)
        {
            return;
        }
        whenEnter?.Invoke(); //invoke ile verdiğimiz komut çalışır 
       
    }
}
