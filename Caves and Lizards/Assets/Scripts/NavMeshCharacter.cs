using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCharacter : MonoBehaviour
{   
    
    private NavMeshAgent navMeshAgent;
<<<<<<< HEAD
    [SerializeField] private CombatTime combatScript;

    private bool hasCombatStarted = false;
=======
<<<<<<< HEAD
=======

>>>>>>> 747a3663bb9a8ba835bd3578a67ff5306e167789
    public Grid gridComponent;
>>>>>>> 2594fe09400e5c977cf6a25d93ee384733f4d1fc

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
        // grid = Testgrid.GetComponent<Grid>();
>>>>>>> 747a3663bb9a8ba835bd3578a67ff5306e167789
>>>>>>> 2594fe09400e5c977cf6a25d93ee384733f4d1fc
    }

    // Update is called once per frame
    void Update()
<<<<<<< HEAD
    {   
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hitSmth = Physics.Raycast(ray, out RaycastHit hitInfo);

        bool isCombatTime = combatScript.isItCombatTime();

        if (hitSmth)
=======
    {
<<<<<<< HEAD

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hitSmth = Physics.Raycast(ray, out RaycastHit hitInfo);
        int xCoordGrid = gridComponent.GetX(hitInfo.point);
        int yCoordGrid = gridComponent.GetY(hitInfo.point);

        if (hitSmth)
        {
            Vector3 gridCentre = gridComponent.GetWorldPositionCentre(xCoordGrid, yCoordGrid);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse 1 Pressed");
                navMeshAgent.SetDestination(gridCentre);
            }
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Mouse 2 Pressed, movement stopped");
                navMeshAgent.SetDestination(transform.position);
            }
        }


=======
        if (Input.GetMouseButtonDown(1))
>>>>>>> 2594fe09400e5c977cf6a25d93ee384733f4d1fc
        {
            if (isCombatTime && !hasCombatStarted)
            {
                Debug.Log("Combat Started, movement stopped!");
                hasCombatStarted = true;
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
<<<<<<< HEAD


=======
>>>>>>> 747a3663bb9a8ba835bd3578a67ff5306e167789
>>>>>>> 2594fe09400e5c977cf6a25d93ee384733f4d1fc
    }

}
