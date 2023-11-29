using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public bool slotGameDone;
    public bool chessGameDone;
    public bool mapGameDone;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        slotGameDone = false;
        chessGameDone = false;
        mapGameDone = false;
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}