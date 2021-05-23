using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chase :RunToHeaven
{
    /// <summary>
    /// Kovalamaca durumunda mıyım ?
    /// </summary>
    public bool isChase;
    [Tooltip("Kovalayacak karakter.")]
    public Transform transform;

    private Transform other;
    [Tooltip("Player'ı kovalarken hız")]
    public float speed = 1.5f;
    [Tooltip("player'a ne kadar yaklaşırsak yakalanma durumu olsun ? ")]
    public float catchMaxDistance=0.5f;
    [Tooltip("player ne kadar uzağa giderse kaybolsun ? ")]
    public float lostDistance = 5;
    
   /// <summary>
   /// Hedef belirlenir ve attack için hazırlık yapılır.
   /// </summary>
   /// <param name="other">Hedef</param>
    public void AttackTarget(Transform other)
    {
        this.other = other;
        isChase = true;
    }
    /// <summary>
    /// Hedef belirlenmiş ve atak yapılır.
    /// </summary>
    public void AttackTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, other.position, Time.deltaTime * speed);
    }
    /// <summary>
    /// Kovalamaca'da eğer player yakalanırsa true döndürür.
    /// </summary>
    /// <returns></returns>
    public bool Catch()
    {
        //istenilen max değere ulaştı ise true, ulaşmadıysa false döndür.
        if (Vector3.Distance(transform.position,other.position) < catchMaxDistance)
        {
           
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Player'ı kaybetme mesafesi (herhangi bir işlem yapılmadı.)
    /// </summary>
    /// <returns></returns>
    public bool Lost()
    {
        if (Vector3.Distance(transform.position, other.position) < lostDistance)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
