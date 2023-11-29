using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public bool slotGameDone;
    public bool chessGameDone;
    public bool mapGameDone;
    public bool codePuzzleDone;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        codePuzzleDone = false;
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