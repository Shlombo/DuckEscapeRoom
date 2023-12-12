using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPuzzle : MonoBehaviour
{
    public Slot slot1;
    public Slot slot2;
    public Slot slot3;
    public Slot slot4;
    public Slot slot5;
    public Draggable correct1;
    public Draggable correct2;
    public Draggable correct3;
    public Draggable correct4;
    public Draggable correct5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(slot1.item == correct1 && slot2.item == correct2 && slot3.item == correct3 && slot4.item == correct4 && slot5.item == correct5 ) {
            GameManager.Instance.slotGameDone = true;
        }
    }
}
