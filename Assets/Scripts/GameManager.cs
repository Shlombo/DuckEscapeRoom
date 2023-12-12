using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public bool slotGameDone;
    public bool chessGameDone;
    public bool codePuzzleDone;
    public bool disentanglementPuzzleDone;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        codePuzzleDone = false;
        slotGameDone = false;
        chessGameDone = false;
        disentanglementPuzzleDone = false;
    }

    void Update()
    {
        
    }
}