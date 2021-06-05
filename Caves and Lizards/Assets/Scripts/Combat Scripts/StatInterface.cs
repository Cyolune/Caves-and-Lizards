using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StatInterface
{   
    float getInitiative();
    bool hasEndedTurn();
    void startTurn();
    void endTurn();
    bool isAlive();
}
