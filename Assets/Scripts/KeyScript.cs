using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCamera; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // using ray cating to determine if key is covered
        // position of ray
        Vector2 rayPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        // hits of ray
        RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.transform == transform)
            {
                // key not covered since the key is reached by ray
                SceneManager.LoadScene("Room 3");
                GameManager.Instance.disentanglementPuzzleDone = true;
                
            }
        }
        
    }
    

}
