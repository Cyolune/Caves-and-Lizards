using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCharacter : MonoBehaviour
{   
    private NavMeshAgent navMeshAgent;
<<<<<<< HEAD
=======

>>>>>>> 747a3663bb9a8ba835bd3578a67ff5306e167789
    public Grid gridComponent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
<<<<<<< HEAD
=======
        // grid = Testgrid.GetComponent<Grid>();
>>>>>>> 747a3663bb9a8ba835bd3578a67ff5306e167789
    }

    // Update is called once per frame
    void Update()
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
>>>>>>> 747a3663bb9a8ba835bd3578a67ff5306e167789
    }

}
