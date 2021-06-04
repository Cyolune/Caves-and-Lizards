using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PQNS;
using Char;

public class Combat : MonoBehaviour
{
    // How to do this? Attach stats to a player and be able to retrieve it
    public GameObject player;
    PriorityQueue<Character> inCombat = new PriorityQueue<Character>();
    bool hasStartedCombat = false;

    private Collider[] combatStartSphere;

    // How to do this? Initialise Turn Order so we can pass the Turn Handling to it instead of here.
    private TurnOrder turnOrder = new TurnOrder();

    // Start is called before the first frame update
    void Start()
    {
        // Need to fix this too
        inCombat.Enqueue(player.GetComponent<Character>());
    }

    // Update is called once per frame
    void Update()
    {
        combatStartSphere = Physics.OverlapSphere(player.transform.position, 5);
        // Gets all enemies within a certain radius and set them to be in combat
        foreach (Collider collider in combatStartSphere)
        {
            Character inRadius = collider.GetComponentInParent<GameObject>().GetComponent<Character>();
            if (!inRadius.isInCombat)
            {
                inCombat.Enqueue(inRadius);
                inRadius.isInCombat = true;
            }
        }
        if (!hasStartedCombat && inCombat.Count() > 1)
        {
            hasStartedCombat = true;
            turnOrder.init(inCombat);
        } else if (inCombat.Count() == 1)
        {
            hasStartedCombat = false;
        }
 
    }
}
