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
    [Tooltip("Point noktaları takip edecek obje.")]
    public Transform transform;
    [Tooltip("Point noktaları")]
    public Transform[] points;
    [Tooltip("döngü olacak mı ? eğer false olursa son noktada durur")]
    public bool isCircle;
    [Tooltip("objenin pointe giderken hızı")]
    public float speed = 1;
    [Tooltip("Point'e vardıktan sonra bekleme yeni bir point'e haret etmeden önce bekleme süresi(bekleme,veya bir idle,turn animasyonları eklenebilr)")]
    public float waitOnPointTime;
    [Tooltip("Hangi point noktasına hareket ettiğimizi belirtir.")]
    private int pointCounter;
    [Tooltip("Yön belirleneceği zaman bir önceki konumu tutar.")]
    private Vector3 keepTurn;
    [Tooltip("yön belirtir.")]
    private Vector3 direction;
    

    public void StartPosition()
    {
        transform.position = points[0].position; //oyun başladığında ilk point noktasına transform yerleştirilir.
        pointCounter++;//hedef point belirlenir.
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

    public MovePoint MoveToNextPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[pointCounter].position, Time.deltaTime * speed);
        return this;
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
    /// <summary>
    /// Döndürme işlemi yapılır.
    /// </summary>
    /// <returns></returns>
    public MovePoint Turn()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - keepTurn, Vector3.up);
        return this;
    }
    /// <summary>
    /// Yön Belirlenir.
    /// </summary>
    /// <returns></returns>
    private MovePoint Direction()
    {
        direction = transform.position - keepTurn; 
        return this;
    }
    /// <summary>
    /// pozisyon tutulur.
    /// </summary>
    /// <returns></returns>
    private MovePoint Keep()
    {
        keepTurn = transform.position; 
        return this;
    }
    /// <summary>
    /// Hareket ve döndürme işlemi yapılır.
    /// </summary>
    public void MoveToNextPointAndTurn()
    {
       Keep()
            .MoveToNextPoint()
            . Direction()
            .Turn();
    }
}
