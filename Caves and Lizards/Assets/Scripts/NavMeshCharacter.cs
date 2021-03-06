using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCharacter : MonoBehaviour
{   
    
    private NavMeshAgent navMeshAgent;
    [SerializeField] private CombatTime combatScript;

    private bool hasCombatStarted = false;

    private bool canMove = true; //will be set to false when it is not on player's turn.
    public void setCannotMove() {canMove = false;}
    public void setCanMove() {canMove = true;}

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hitSmth = Physics.Raycast(ray, out RaycastHit hitInfo);

        bool isCombatTime = combatScript.isItCombatTime();

        if (hitSmth && canMove)
        {
            if (isCombatTime && !hasCombatStarted)
            {
                Debug.Log("NavMeshChar.cs: Combat Started, movement stopped!");
                hasCombatStarted = true;
                navMeshAgent.SetDestination(transform.position);
            } else if (!isCombatTime && hasCombatStarted)
            {
                Debug.Log("NavMeshChar.cs: Combat ended, normal movement allowed!");
                hasCombatStarted = false;
            }
            if (Input.GetMouseButtonDown(0) && !isCombatTime)
            {
                Debug.Log("Mouse 1 Pressed");
                navMeshAgent.SetDestination(hitInfo.point);
            }
            if (Input.GetMouseButtonDown(1) && !isCombatTime)
            {
                Debug.Log("Mouse 2 Pressed, movement stopped");
                navMeshAgent.SetDestination(transform.position);
            }
        }


    }

}
