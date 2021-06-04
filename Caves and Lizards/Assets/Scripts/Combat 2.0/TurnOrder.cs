using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PQNS;
using Char;

public class TurnOrder : MonoBehaviour
{
    private PriorityQueue<Character> pq;
    private Character thisGuysTurn;
    public void init(PriorityQueue<Character> pq)
    {
        this.pq = pq;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pq == null) return;
        
        if (thisGuysTurn.hasEndedTurn) {
            if (thisGuysTurn.isAlive) {
                thisGuysTurn.initiative += 100;
                pq.Enqueue(thisGuysTurn);
            }
            thisGuysTurn = pq.Dequeue();
        } else {
            // wait for the turn to end.
        }
    }
}
