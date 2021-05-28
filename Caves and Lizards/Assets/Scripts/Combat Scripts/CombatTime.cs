using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PQNS; // Priority Queue
using Char; // Characters

public class CombatTime : MonoBehaviour
{   
    private bool isCombatTime;

    // placed here temporarily for later usage.
    public PriorityQueue<Character> unitsInCombat = new PriorityQueue<Character>();

    public List<GameObject> combatUnitsList = new List<GameObject>();

    public GameObject player;
    // Simple combat between these two GameObjects
    public GameObject enemy1;

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
        if (isCombatTime && player.GetComponent<PlayerStats>().hasEndedTurn)
        {
            GameObject turn = combatUnitsList[0];
            combatUnitsList.RemoveAt(0);
            Debug.Log("Its " + turn + "'s Turn!");
            Debug.Log("Currently unable to go to next turn");
        }
        if (isCombatTime && !enemy1.GetComponent<Stat>().isAlive)
        {
            Debug.Log("Combat ended!");
            isCombatTime = false;
        }
        if (!isCombatTime && distance < 5 && enemy1.GetComponent<Stat>().isAlive)
        {   
            Debug.Log("Combat started!");
            isCombatTime = true;
        }
    }

    public bool isItCombatTime() {
        return isCombatTime;
    }

    private void InitialiseCombatUnits() {
        // Add enemy units to list in descending order
        combatUnitsList.Add(enemy1);

        // Insert player unit to the list

        
        int playerInitiative = player.GetComponent<PlayerStats>().Initiative;
        int startIndex = 0;
        while(combatUnitsList[startIndex].GetComponent<Stat>().Initiative > playerInitiative) {
            startIndex++;
        }
        combatUnitsList.Insert(startIndex, player);
    }
}
