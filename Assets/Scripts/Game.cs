using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //Reference from Unity IDE
    public GameObject chesspiece;

    //Matrices needed, positions of each of the GameObjects
    //Also separate arrays for the players in order to easily keep track of them all
    //Keep in mind that the same objects are going to be in "positions" and "playerBlack"/"playerWhite"
    private GameObject[,] positions = new GameObject[6, 6];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    //current turn
    private string currentPlayer = "white";

    //Game Ending
    private bool gameOver = false;
    
    public int enemyKillCount = 0;
    
    public int level;

    //Unity calls this right when the game starts, there are a few built in functions
    //that Unity can call for you
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
        
        for (int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
    }

	public GameObject[] getBlackPieces()
	{
		return playerBlack;
	}

    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>(); //We have access to the GameObject, we need the script
        cm.name = name; //This is a built in variable that Unity has, so we did not have to declare it before
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
       			currentPlayer = "black";
        		if ( playerBlack[i] != null )
        		{
        			GameObject obj = playerBlack[i];
        			Chessman cm = obj.GetComponent<Chessman>(); //We have access to the GameObject, we need the script
        			cm.InitiateMovePlates();
        		}
        	}
        
        currentPlayer = "white";
    }

    public void Update()
    {
		if (enemyKillCount == playerBlack.Length)
		{
			System.Threading.Thread.Sleep(250);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameManager.Instance.chessGameDone = true;
		}        
    }
    
    public void Winner(string playerWinner)
    {
        gameOver = true;
        //Using UnityEngine.UI is needed here
        GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().enabled = true;
        if (currentPlayer == "black") {
        	GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = "You Lose :(";
		} else {
			GameObject.FindGameObjectWithTag("WinnerText").GetComponent<Text>().text = "You Win!";
		}
        //GameObject.FindGameObjectWithTag("RestartText").GetComponent<Text>().enabled = true;
    }
}
