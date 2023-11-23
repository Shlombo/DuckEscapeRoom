using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    // public static Navigation Instance;

    public string lastScene;

    public Room currentRoom;

    public Room startRoom;

    [Serializable]
    public struct Room {
        public string name;
        public int index;
    }
    public Room[] roomList;
    
    private void Awake()
    {
        // if (Instance != null)
        // {
        //     Destroy(gameObject);
        //     return;
        // }
        // Instance = this;

        currentRoom = startRoom;


        // DontDestroyOnLoad(gameObject);
    }

    public void ZoomSlotGame() {
        Debug.Log(SceneManager.GetActiveScene().name);
        lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("SlotGame");
    }

    public void LastScene() {
        SceneManager.LoadScene(lastScene);
        lastScene = null;
    }

    public void GoLeft() {
        int idx = currentRoom.index - 1;
        if(idx >= 0) {
            currentRoom = roomList[idx];
            SceneManager.LoadScene(roomList[idx].name);
        }
    }

    public void GoRight() {
        int idx = currentRoom.index + 1;
        if(idx < roomList.Length) {
            currentRoom = roomList[idx];
            SceneManager.LoadScene(roomList[idx].name);
        }
    }

    public void LoadRoom(string name) {
        SceneManager.LoadScene(name);
    }
}
