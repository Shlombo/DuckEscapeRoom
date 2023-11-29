using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridMovement : MonoBehaviour
{
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    private bool isMoving;
    private Vector2 origPos, targetPos;
    private float timeToMove = 0.5f;

    private bool faceLeft;
    private bool faceRight;
    private bool faceUp;
    private bool faceDown;

    private KeyCode[] solution =
    {
        KeyCode.UpArrow,
        KeyCode.UpArrow,
        KeyCode.RightArrow,
        KeyCode.RightArrow,
        KeyCode.RightArrow,
        KeyCode.RightArrow,
        KeyCode.UpArrow,
        KeyCode.LeftArrow,
        KeyCode.LeftArrow,
        KeyCode.DownArrow,
        KeyCode.DownArrow
    };
    private int solutionIndex = 0;

    private void Start()
    {
        faceLeft = false;
        faceRight = false;
        faceUp = false;
        faceDown = true;

        spawnPosition = transform.position;
        spawnRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

        if (solutionIndex == 11 && !isMoving)
        {
            System.Threading.Thread.Sleep(250);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKey(KeyCode.DownArrow) && !isMoving)
        {
            if (solution[solutionIndex] == KeyCode.DownArrow)
            {
                solutionIndex++;
                StartCoroutine(MovePlayer(new Vector2(0f, -1.2f)));
            }
            else
            {
                solutionIndex = 0;
                transform.position = spawnPosition;
                transform.rotation = spawnRotation;
                faceLeft = false;
                faceRight = false;
                faceUp = false;
                faceDown = true;
                System.Threading.Thread.Sleep(150);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) && !isMoving)
        {
            if (solution[solutionIndex] == KeyCode.UpArrow)
            {
                solutionIndex++;
                StartCoroutine(MovePlayer(new Vector2(0f, 1.2f)));
            }
            else
            {
                solutionIndex = 0;
                transform.position = spawnPosition;
                transform.rotation = spawnRotation;
                faceLeft = false;
                faceRight = false;
                faceUp = false;
                faceDown = true;
                System.Threading.Thread.Sleep(150);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving)
        {
            if (solution[solutionIndex] == KeyCode.LeftArrow)
            {
                solutionIndex++;
                StartCoroutine(MovePlayer(new Vector2(-1.2f, 0f)));
            }
            else
            {
                solutionIndex = 0;
                transform.position = spawnPosition;
                transform.rotation = spawnRotation;
                faceLeft = false;
                faceRight = false;
                faceUp = false;
                faceDown = true;
                System.Threading.Thread.Sleep(150);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) && !isMoving)
        {
            if (solution[solutionIndex] == KeyCode.RightArrow)
            {
                solutionIndex++;
                StartCoroutine(MovePlayer(new Vector2(1.2f, 0f)));
            }
            else
            {
                solutionIndex = 0;
                transform.position = spawnPosition;
                transform.rotation = spawnRotation;
                faceLeft = false;
                faceRight = false;
                faceUp = false;
                faceDown = true;
                System.Threading.Thread.Sleep(150);
            }
        }
    }

    private IEnumerator MovePlayer(Vector2 direction)
    {
        isMoving = true;

        // Rotation if moving up
        if (direction.y > 0)
        {
            // If the sprite is facing down, rotate 180 degrees
            if (faceDown)
            {
                faceDown = false;
                transform.Rotate(Vector3.forward * 180);
            }
            // If the sprite is facing right, rotate 90 degrees
            else if (faceRight)
            {
                faceRight = false;
                transform.Rotate(Vector3.forward * 90);
            }
            // If the sprite is facing left, rotate 90 degrees
            else if (faceLeft)
            {
                faceLeft = false;
                transform.Rotate(Vector3.forward * -90);
            }
            faceUp = true;
        } 
        // Rotation if moving down
        else if (direction.y < 0)
        {
            // If the sprite is facing up, rotate 180 degrees
            if (faceUp)
            {
                faceUp = false;
                transform.Rotate(Vector3.forward * 180);
            }
            // If the sprite is facing right, rotate 90 degrees
            else if (faceRight)
            {
                faceRight = false;
                transform.Rotate(Vector3.forward * -90);
            }
            // If the sprite is facing left, rotate 90 degrees
            else if (faceLeft)
            {
                faceLeft = false;
                transform.Rotate(Vector3.forward * 90);
            }
            faceDown = true;
        }
        // Rotation if moving right
        else if (direction.x > 0)
        {
            // If the sprite is facing left, rotate 180 degrees
            if (faceLeft)
            {
                faceLeft = false;
                transform.Rotate(Vector3.forward * 180);
            }
            // If the sprite is facing up, rotate 90 degrees
            else if (faceUp) 
            {
                faceUp = false;
                transform.Rotate(Vector3.forward * -90);
            }
            // If the sprite is facing down, rotate 90 degrees
            else if (faceDown)
            {
                faceDown = false;
                transform.Rotate(Vector3.forward * 90);
            }
            faceRight = true;
        }
        // Rotation if moving left
        else if (direction.x < 0)
        {
            // If the sprite is facing right, rotate 180 degrees
            if (faceRight)
            {
                faceRight = false;
                transform.Rotate(Vector3.forward * 180);
            }
            // If the sprite is facing up, rotate 90 degrees
            else if (faceUp)
            {
                faceUp = false;
                transform.Rotate(Vector3.forward * 90);
            }
            // If the sprite is facing down, rotate 90 degrees
            else if (faceDown)
            {
                faceDown = false;
                transform.Rotate(Vector3.forward * -90);
            }
            faceLeft = true;
        }

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector2.Lerp(origPos, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
