using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public int Initiative = 70;
    public bool isAlive = true;
    public bool hasEndedTurn = false;
    public bool isTurn = false;
    void Update() {
        if (isTurn) {
            hasEndedTurn = false;
            //check for inputs etc...
            //end turn here
        }
        hasEndedTurn = true;
    }

    public void startTurn() {
        isTurn = true;
    }
}
