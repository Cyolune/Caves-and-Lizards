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
    }

    // Update is called once per frame
    void Update()
    {

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


    }

}
