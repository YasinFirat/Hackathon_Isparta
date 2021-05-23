using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Burada scene ile yapılacak işlemler yapılır.
/// </summary>
public class SceneControl : MonoBehaviour
{
    /// <summary>
    /// Tekrardan oynat
    /// </summary>
    public void RePlay()
    {
        SceneManager.LoadScene(builtIndex);
    }
    /// <summary>
    /// Bir sonraki seviye
    /// </summary>
    public void NextLevel()
    {
        if(SceneManager.sceneCount> builtIndex + 1)
        {
            return;
        }
        SceneManager.LoadScene(builtIndex+1);
    }
    /// <summary>
    /// Belirtilen sahneyi aç    /// </summary>
    /// <param name="index"></param>
    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    /// <summary>
    /// Bir önceki sahneye git
    /// </summary>
    public void GoBackScene()
    {
        if (builtIndex == 0)
            return;
        SceneManager.LoadScene(builtIndex-1);
    }
    /// <summary>
    /// Aktif sahneyi döndür.
    /// </summary>
    private int builtIndex
    {
        get
        {
            return SceneManager.GetActiveScene().buildIndex;
        }
    }
}
