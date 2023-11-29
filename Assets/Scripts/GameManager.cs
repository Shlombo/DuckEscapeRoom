using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public bool slotGameDone;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        slotGameDone = false;
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}