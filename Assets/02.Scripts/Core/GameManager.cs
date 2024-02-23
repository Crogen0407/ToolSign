using System;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Player Player { get; private set; }
    
    private void Awake()
    {
        Player = FindObjectOfType<Player>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
