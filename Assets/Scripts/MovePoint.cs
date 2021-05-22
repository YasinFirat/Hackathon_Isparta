using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Karakterin belirtilen konumlara göre hareket etmesini sağlar. 
/// Şimdilik gittiği yönden ilerlemiyor. 0,1,2..., n ,0,1,2 .. n  gibisinden ilerleme mevcut
/// Eğer istenirse 0,1,2 .. n , n-1 , n-2 , 0 ,1 ,2 ... şeklinde tasarlanır.
/// Fakat şu anda ilk durum ihtiyacımızı karşılamakta.
/// </summary>
[System.Serializable]
public class MovePoint
{
    public Transform transform;
    public Transform[] points;
    public bool isCircle;
    public float speed = 1;
    public float waitOnPointTime;
    private int pointCounter;

    public void StartPosition()
    {
        transform.position = points[0].position;
        pointCounter++;

    }
    /// <summary>
    /// Hedef konumunu tespit eder.
    /// </summary>
    public void CheckPointCounter()
    {
        if (pointCounter + 1 >= points.Length) //eğer bir sonraki adım point dizisinden küçük ise
        {
            //Döngü içerisinde olacaksa hedef konumu ilk konum olarak belirle
            if (isCircle)
            {
                pointCounter = 0; //hedef konum güncellenir
            }
        }
        else
        {
            pointCounter++; //hedef konum güncellenir.
        }
    }
    /// <summary>
    /// Gerekli objeyi hedef konuma taşır.
    /// </summary>

    public void MoveToNextPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[pointCounter].position, Time.deltaTime * speed);
    }
    /// <summary>
    /// Hedef konuma belirlediğiniz değere kadar ulaşınca true döndürür.
    /// </summary>
    /// <param name="maxDistance">Hedefe ne kadar yaklaşırsak true döndürsün ? </param>
    /// <returns></returns>
    public bool Arrive(float maxDistance)
    {
        //istenilen max değere ulaştı ise true, ulaşmadıysa false döndür.
        if (Vector3.Distance(transform.position, points[pointCounter].position) < maxDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
