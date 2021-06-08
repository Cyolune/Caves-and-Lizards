using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCharacter : MonoBehaviour
{   
    private NavMeshAgent navMeshAgent;
    public CombatTime combatScript;
    public PlayerProperties playerStatScript;
    private bool hasCombatStarted = false;
    private bool regenAPAlready = false;
    private float leftoverMovement = 0;
    private float timeTracker;
    private Vector3 oldPos;
    private NavMeshPath navPath;
    public LineRenderer lineRenderer;

    public bool canMove = true;

    public GameObject distanceAPHandler;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navPath = new NavMeshPath();
        timeTracker = Time.time;

        lineRenderer.startWidth = 0.15f;
        lineRenderer.endWidth = 0.15f;
        lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if (canMove) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitSmth = Physics.Raycast(ray, out RaycastHit hitInfo);

            bool isCombatTime = combatScript.isItCombatTime();
            if (hitSmth)
            {   
                Vector3 dest = hitInfo.point;
                Vector3 playerPos = transform.position;

                //Draw path code
                NavMesh.CalculatePath(playerPos, dest, 1, navPath);
                Vector3[] corners = navPath.corners;
                
                float dist = DrawPath(corners);
        
                if (isCombatTime)
                {   
                    bool isPlayerTurn = combatScript.player.Equals(combatScript.currTurnUnit);
                    
                    if (!hasCombatStarted)
                    {   // When first entering combat time.
                        Debug.Log("NavMeshChar.cs: Combat Started, movement stopped!");
                        hasCombatStarted = true;
                        navMeshAgent.SetDestination(transform.position);
                        oldPos = transform.position;
                    }
                    if (isPlayerTurn)
                    {   // Player's turn
                        if (!regenAPAlready)
                        {
                            playerStatScript.getStats().recoverAP();
                            regenAPAlready = true;
                        }
                        
                        float APCostingMovement = dist - leftoverMovement;
                        float APCost;
                        if (APCostingMovement <= 0) 
                        {
                            APCost = 0;
                        } 
                        else 
                        {
                            APCost = Mathf.Ceil(APCostingMovement / playerStatScript.getStats().getMovementPerAP()); 
                        }
                        Debug.Log("AP:" + playerStatScript.getStats().getAP());

                        distanceAPHandler.GetComponent<DistanceAPDisplay>().updateText(dist, APCost);
                        if (Input.GetMouseButtonDown(0)) 
                        {
                            if (APCost > playerStatScript.getStats().getAP())
                            { // not enuf AP
                                // TODO: TELL USER CANNOT MOVE COS MOVE TOO FAR
                                Debug.Log("NavMeshChar: Cannot move, too much AP used");
                            }
                            else // enuf AP 
                            {   
                                navMeshAgent.SetDestination(hitInfo.point);
                                if (leftoverMovement <= 0) 
                                {
                                    playerStatScript.getStats().useAP(1);
                                    leftoverMovement += playerStatScript.getStats().getMovementPerAP();
                                }
                            }
                        }
                                                
                        // Real time AP consumption code
                        if (Time.time - timeTracker > 0.1) 
                        {
                            Vector3 currPos = transform.position;
                            float movedDist = Vector3.Distance(oldPos, currPos);
                            leftoverMovement -= movedDist;
                            timeTracker = Time.time;
                            oldPos = currPos;
                            if (leftoverMovement <= 0 && movedDist > 0 && playerStatScript.getStats().getAP() > 0) 
                            {
                                playerStatScript.getStats().useAP(1);
                                leftoverMovement += playerStatScript.getStats().getMovementPerAP();
                            } else if (playerStatScript.getStats().getAP() == 0) 
                            {
                                navMeshAgent.SetDestination(transform.position);
                            }
                        }

                    }
                    else // if not player's turn
                    {
                        regenAPAlready = false;
                        leftoverMovement = 0;
                    }
                }   
                else //if not combatTime
                {
                    if (hasCombatStarted)
                    {
                        Debug.Log("NavMeshChar.cs: Combat ended, normal movement allowed!");
                        hasCombatStarted = false;
                    }
                    if (Input.GetMouseButtonDown(0)) navMeshAgent.SetDestination(hitInfo.point);
                }
                if (Input.GetMouseButtonDown(1)) {
                    Debug.Log("NavMeshChar.cs: Mouse 2 Pressed, movement stopped");
                    navMeshAgent.SetDestination(transform.position);
                }
            } // if hit smth
        } // if can move
    }

    private float DrawPath(Vector3[] path) {
        lineRenderer.positionCount = path.Length;
        lineRenderer.SetPosition(0, transform.position);
        float dist = 0;

        if (path.Length < 2) { // Path taken is a point
            return dist;
        } else {
            for (int i = 1; i < path.Length; i++) {
                lineRenderer.SetPosition(i, path[i]);
                dist += Vector3.Distance(path[i - 1], path[i]);
            }
            return dist;
        }
    }
}
