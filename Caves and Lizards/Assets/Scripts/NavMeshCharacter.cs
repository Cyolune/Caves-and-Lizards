using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCharacter : MonoBehaviour
{   
    private NavMeshAgent navMeshAgent;

    public Grid gridComponent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        // grid = Testgrid.GetComponent<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Input passes");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitSmth = Physics.Raycast(ray, out RaycastHit hitInfo);

            if (hitSmth)
            {   
                int xCoordGrid = gridComponent.GetX(hitInfo.point);
                int yCoordGrid = gridComponent.GetY(hitInfo.point);
                Vector3 gridCentre = gridComponent.GetWorldPositionCentre(xCoordGrid, yCoordGrid);
                navMeshAgent.SetDestination(gridCentre);
            }
        }
    }

}
