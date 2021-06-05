using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsNS;

public class EnemyStat : MonoBehaviour, StatInterface
{
    Stats stats;

    public bool isTurn;

    public float hP;

    // Start is called before the first frame update
    void Start()
    {
        float[] temp = {1, 1, 1, 1, 1, 1};
        stats = new Stats(temp);
        hP = stats.getCurrentHP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public float getInitiative() {return stats.initiative();}

    public bool hasEndedTurn() {return !isTurn;}

    public void startTurn() {isTurn = true;}

    public void endTurn() {isTurn = false;}
    public bool isAlive() {
        return hP > 0;
    }
}
