using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsNS;

public interface StatInterface
{   
    bool hasEndedTurn();
    void startTurn();
    void endTurn();
    Stats getStats();
}
