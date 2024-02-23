using System;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Player Player { get; private set; }
    
    private void Awake()
    {
        Player = FindObjectOfType<Player>();
    }
}
