using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	//References to objects in our Unity Scene
    public GameObject chesspiece;
    public int level;

    //Positions of each of the GameObjects
    private GameObject[,] positions = new GameObject[6, 6];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    //Current Turn
    private string currentPlayer = "white";

    //Game Ending
    private bool gameOver = false;
    
    //Counter for Goose pieces taken, used for win condition
    public int enemyKillCount = 0;

    public void Start()
    {
        playerWhite = new GameObject[] { Create("white_bishop", 0, 0) };
        
        if (level == 1)
        {
        	playerBlack = new GameObject[] { Create("black_king", 5, 5)};
        }
        else if (level == 2)
        {
        	playerBlack = new GameObject[] { Create("black_king", 3, 5), Create("black_rook", 2, 4) };
        } 
        else if (level == 3)
        {
        	playerBlack = new GameObject[] { Create("black_king", 5, 1), Create("black_rook", 3, 1),
        	Create("black_rook", 2, 5) };
        }

        //Set all piece positions on the positions board
        
        SetPosition(playerWhite[0]);
        for (int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
        }
    }

	public GameObject[] getBlackPieces()
	{
		return playerBlack;
	}

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = name; 
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.Activate(); //It has everything set up so it can now Activate()
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Chessman cm = obj.GetComponent<Chessman>();

        //Overwrites either empty space or whatever was there
        positions[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }

    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1)) return false;
        return true;
    }

    public string GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void NextTurn()
    {   
    	for (int i = 0; i < playerBlack.Length; i++)
       	{
       		//Checks all black pieces to see if white bishop is in check
       		currentPlayer = "black";
        	if ( playerBlack[i] != null )
        	{
        		GameObject obj = playerBlack[i];
        		Chessman cm = obj.GetComponent<Chessman>();
        		cm.InitiateMovePlates();
        		
        		if (!gameOver) cm.DestroyMovePlates();
        	}
        }
        
        currentPlayer = "white";
    }

    public void Update()
    {
    	//Used for win condition
		if (enemyKillCount == playerBlack.Length)
		{
			System.Threading.Thread.Sleep(250);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}    
		
		//Used for win condition, edge case for Level 3
		if (level == 3 && enemyKillCount == 2)
		{
			System.Threading.Thread.Sleep(250);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		
		//Reloads game
		if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            gameOver = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public void Winner(string playerWinner)
    {
        gameOver = true;

        if (playerWinner == "black") GameObject.FindGameObjectWithTag("RestartText").GetComponent<Text>().enabled = true;
    }
}
