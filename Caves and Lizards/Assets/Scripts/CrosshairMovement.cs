using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/** This script encapsulates the rendering and movement of crosshair
 *
 * The crosshair is a visual representation of where the mouse is pointing at.
 * This script will check and detect if the player is moving or not, and
 * show the grid square that the mouse is pointing at
 */ 
public class CrosshairMovement : MonoBehaviour
{
    // public Grid gridComponent;
    public Grid gridComponent;
    public GameObject player;
    private Vector3 playerLastPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerCurrPos = player.transform.position;
        if (playerCurrPos != playerLastPos || Input.GetMouseButton(1))
        { // If the player is moving, disable rendering crosshair.
        // If right click is held (for camera rotation), disable rendering crosshair
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
    }

}
