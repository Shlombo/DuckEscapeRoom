using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    private Collider2D myCollider;

    void Start()
    {
        //initialize
        mainCamera = Camera.main; 
        myCollider = GetComponent<Collider2D>(); 
    }

    void OnMouseDown()
    {
        //get offset of move
        offset = transform.position - GetMousePos();
    }

    void OnMouseDrag()
    {
        Vector3 newPosition = GetMousePos() + offset;


        if (!IsOverlapping(newPosition))
        {
            //move
            transform.position = newPosition;
        }
    }
    //get current mouse world pos
    private Vector3 GetMousePos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    // check if new pos overlapping 
    private bool IsOverlapping(Vector3 newPos)
    {
        if (GetComponent<Collider2D>() != null)
        {
            Vector2 direction = newPos - transform.position;
            //distance
            float dist = direction.magnitude;
            //using raycasting to detect
            RaycastHit2D[] hits = new RaycastHit2D[10];

            int n = GetComponent<Collider2D>().Cast(direction, new ContactFilter2D().NoFilter(), hits, dist);

            for (int i = 0; i < n; i++)
            {
                if (hits[i].collider != null && hits[i].collider != GetComponent<Collider2D>() && hits[i].collider != GameObject.Find("Key").GetComponent<BoxCollider2D>())
                {   
                    //collide
                    return true; 
                }
            }
        }
        //desn't collide
        return false;
    }
}