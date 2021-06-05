using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTime : MonoBehaviour
{   
    private bool isCombatTime;
    public List<GameObject> combatUnitsList = new List<GameObject>();
    public int unitsInCombat;
    public GameObject player;

    // Player stat component
    public StatInterface playerStat;

    // Simple combat between these two GameObjects
    public GameObject enemy1;

    // Enemy1 stat component
    public StatInterface enemy1Stat;

    // Current unit that is taking their turn
    public GameObject currTurnUnit;

    // Current index of unit taking the turn in the combatUnitList
    public int currUnitIndex;


    // Start is called before the first frame update
    void Start()
    {
        isCombatTime = false;
        InitialiseCombatUnits();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance (player.transform.position, enemy1.transform.position);
        if (isCombatTime && currTurnUnit.GetComponent<StatInterface>().hasEndedTurn())
        {   
            currUnitIndex = (currUnitIndex + 1) % unitsInCombat;
            currTurnUnit = combatUnitsList[currUnitIndex];
            currTurnUnit.GetComponent<StatInterface>().startTurn();
            Debug.Log("Its " + currTurnUnit + "'s Turn!");
            // Debug.Log("Currently unable to go to next turn");
        }
        if (isCombatTime && !enemy1Stat.isAlive())
        {
            Debug.Log("Combat ended!");
            isCombatTime = false;
        }
        if (!isCombatTime && distance < 4 && enemy1.GetComponent<StatInterface>().isAlive())
        {   
            Debug.Log("Combat started!");
            isCombatTime = true;
        }
    }

    public bool isItCombatTime() {
        return isCombatTime;
    }

    private void InitialiseCombatUnits() {
        // Add enemy units to list in descending order of initiative.
        combatUnitsList.Add(enemy1);
        enemy1Stat = enemy1.GetComponent<StatInterface>();

        // Insert player unit to the list.
        playerStat = player.GetComponent<StatInterface>();
        float playerInitiative = playerStat.getInitiative();
        int startIndex = 0;
        while(combatUnitsList[startIndex].GetComponent<StatInterface>().getInitiative() > playerInitiative) {
            startIndex++;
        }
        combatUnitsList.Insert(startIndex, player);

        unitsInCombat = combatUnitsList.Count;

        // Start the combat with first unit taking the turn.
        currTurnUnit = combatUnitsList[0];
        currUnitIndex = 0;
        currTurnUnit.GetComponent<StatInterface>().startTurn();
    }
}
