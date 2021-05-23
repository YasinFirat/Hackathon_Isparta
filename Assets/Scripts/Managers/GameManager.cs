using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Tooltip("Karakteri yakaladığında gerçekleşecek işlemler")]
    public UnityEvent whenCatch;
    [Tooltip("Görünmezlik tetiklenir ve gerekli islemler buraya eklenir.")]
    public UnityEvent whenSecretEnter;
    [Tooltip("Görünmezlikten çıkılır ve gerekli işlemler buraya eklenir.")]
    public UnityEvent whenSecretExit;
    [Tooltip("Kazanma Durumu")]
    public UnityEvent win;
    [Tooltip("Görünmezlik durumunu belirtir.")]
    [HideInInspector]public bool isPlayerVisible;



    /// <summary>
    /// Player'in düşman tarafından görünür olup olmayacağı seçilir.
    /// </summary>
    /// <param name="isPlayerVisible"></param>
    public void PlayerVisible(bool isPlayerVisible)
    {
        this.isPlayerVisible = isPlayerVisible;
    }

   
    


}
