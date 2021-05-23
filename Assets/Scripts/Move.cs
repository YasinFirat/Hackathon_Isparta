using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : RunToHeaven
{
    [Tooltip("Joystick islemi yapilir.(Kullanmak istediğiniz joystick'i sürükleyiniz)")]
    public VariableJoystick move; //joystick verileri alınır.
    [Tooltip("statik olarak bir speed belirleyin.")]
    [Range(0,1)]
    public float speed;
   
    /// <summary>
    /// Joystick'i sürükleme mesafesine göre değeri artar.(Hareket animasyonları için kullanılabilir.)
    /// </summary>
    public float MoveSpeed { get { return Mathf.Sqrt(Mathf.Pow(move.Horizontal, 2) + Mathf.Pow(move.Vertical, 2));} }
    [Tooltip("pozisyon değiştirilmeden önce mevcut pozisyon aktarılması için çağrılır.")]
    private Vector3 firstPosition;
    /// <summary>
    /// İki nokta arasındaki yönü belirler.
    /// </summary>
    private Vector3 direction;
    /// <summary>
    /// Verilen yöne doğru döndürme işlemi yapar.
    /// </summary>
    private Quaternion lookRotation;

    private void FixedUpdate()
    { 
        //pozisyon değiştirmeden önce simdiki pozisyon tanımlandı.
        firstPosition = transform.position;
        //Pozisyon değiştirildi.
        transform.position += new Vector3(move.Horizontal*speed* MoveSpeed, 0,move.Vertical*speed* MoveSpeed);
        //iki nokta arasındaki yön belirlendi.
        direction = transform.position-firstPosition;
        //Döndürme işlemi yapıldı.
        lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        //döndürme tanımlandı.
        transform.rotation = lookRotation;
    }
    
}
