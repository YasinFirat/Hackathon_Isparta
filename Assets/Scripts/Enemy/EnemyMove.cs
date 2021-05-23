using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyMove : RunToHeaven
{
    [Tooltip("Kovalama için gerekli script")]
    public Chase chase;
    [Tooltip("Enemy'nin takip edeceği noktalar.")]
    public MovePoint movePoint;
    void Start()
    {
        movePoint.StartPosition(); //baslangic noktasi belirlendi.
        movePoint.transform = transform; //noktaları ziyaret edecek(kendisi) transfrom belirlendi
       
    }
    void FixedUpdate()
    {
        if (chase.isChase) // eğer kovalamaca başlaması için uygun ortam sağlandıysa yani radara girdiyse
        {
            chase.AttackTarget(); //düşmana doğru hareket eder.
            if (chase.Catch()) {//eğer yakaladıysa 
                chase.isChase = false;//tekrar point noktalarına gitmesi için yani aşağıdaki kodların çalışması için false oalrak döndürülür.
                gameManager.whenCatch?.Invoke(); //yakalandı ve gerekli komutlar verilir.
            }
            
            
            return;
        }
        movePoint.MoveToNextPointAndTurn(); //hem döndürme işlemi hemde pointlere gitme komutu verilir.
        
       
        if (movePoint.Arrive(.5f))//pointe ulaştığında 
        {
            movePoint.CheckPointCounter(); //yeni bir hedef pointi belirlenir.
        }
       
    }
   
}
