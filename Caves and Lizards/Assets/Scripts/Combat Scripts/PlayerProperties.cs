using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsNS;

public class PlayerProperties : MonoBehaviour, StatInterface
{
    public Stats stats;
    public bool isTurn;
    public float hp; // this does not handle logic, its just there for clarity
    public float AP; // this does not handle logic, its just there for clarity

    // Start is called before the first frame update
    void Start()
    {
        float[] temp = {10, 10, 10, 10, 10, 10};
        stats = new Stats(temp);
        hp = stats.getCurrentHP();
        AP = stats.getAP();
    }

    // Update is called once per frame
    void Update()
    {
        hp = stats.getCurrentHP();   
        AP = stats.getAP(); 
    }

    public bool hasEndedTurn() {return !isTurn;}
    public void startTurn() {isTurn = true;}
    public void endTurn() {isTurn = false;}
    public Stats getStats() {
        return this.stats;
    }
    
}
