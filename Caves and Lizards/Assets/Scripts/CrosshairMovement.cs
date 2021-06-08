using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This script encapsulates the rendering and movement of crosshair
 *
 * The crosshair is a visual representation of where the mouse is pointing at.
 * This script will check and detect if the player is moving or not, and
 * show the grid square that the mouse is pointing at
 */ 
public class CrosshairMovement : MonoBehaviour
{
    // public Grid gridComponent;
    public GameObject player;
    private Vector3 playerLastPos;

    public CombatTime CTScript;

    public bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && CTScript.player == CTScript.currTurnUnit) {
            GetComponent<Renderer>().enabled = true;
            Vector3 playerCurrPos = player.transform.position;
            if (playerCurrPos != playerLastPos || Input.GetMouseButton(2))
            { // If the player is moving, disable rendering crosshair.
            // If middle mouse click is held (for camera rotation), disable rendering crosshair
                GetComponent<Renderer>().enabled = false;
                playerLastPos = playerCurrPos;
            } else { 
                // If player is not moving, enable rendering crosshair and show it
                // according to where the mouse is pointing at
                GetComponent<Renderer>().enabled = true;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool hitSmth = Physics.Raycast(ray, out RaycastHit hitInfo);

                Vector3 newPos = hitInfo.point;
                newPos.y += 0.01f;

                transform.position = newPos;
            }
        } else {
            GetComponent<Renderer>().enabled = false;
        }
    }
    public void disableCHRendering() {
        isActive = false;
    }
    public void enableCHRendering() {
        isActive = true;
    }

}
