using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToHeaven : MonoBehaviour
{
    private GameManager _gameManager;
    public GameManager gameManager
    {
        get
        {
            if (_gameManager == null)
            {
                _gameManager = FindObjectOfType<GameManager>();
                if (_gameManager == null)
                {
                    Debug.LogWarning("GameManager yok!!! Eğer GameManager eklemezsen oyundaki kurallar tetiklenmez.");
                    GameObject gm = new GameObject("Game Manager");
                    gm.AddComponent<GameManager>();
                    _gameManager = gm.GetComponent<GameManager>();
                }
            }

            return _gameManager;
        }
    }
}
