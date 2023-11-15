using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;

    private bool onSlot = false;

    private GameObject closestSlot;

    void Start()
    {

    }
    public void OnMouseDown()
    {
        Debug.Log("DRAG");
        isDragging = true;
        offset = transform.position - (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos + offset;
        } else {
            if(onSlot) {
                transform.position = closestSlot.transform.position;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Slot") {
            Debug.Log("Colliding");
            onSlot = true;
            closestSlot = collision.gameObject;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Slot") {
            Debug.Log("CollidingExit");
            onSlot = false;
        }

    }

    

}
