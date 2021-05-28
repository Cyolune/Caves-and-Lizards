using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCharacter : MonoBehaviour
{   
    
    private NavMeshAgent navMeshAgent;
    [SerializeField] private CombatTime combatScript;

    private bool hasCombatStarted = false;
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

        if (hitSmth)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (isCombatTime && !hasCombatStarted)
                {
                    Debug.Log("Combat Started, movement stopped!");
                     = true;
                    navMeshAgent.SetDestination(transform.position);
                } else if (!isCombatTime && hasCombatStarted)
                {
                    Debug.Log("Combat ended, normal movement allowed!");
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

}
