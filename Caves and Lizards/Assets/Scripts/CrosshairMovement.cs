using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.AI;
=======
>>>>>>> 2594fe09400e5c977cf6a25d93ee384733f4d1fc

/** This script encapsulates the rendering and movement of crosshair
 *
 * The crosshair is a visual representation of where the mouse is pointing at.
 * This script will check and detect if the player is moving or not, and
 * show the grid square that the mouse is pointing at
 */ 
public class CrosshairMovement : MonoBehaviour
{
<<<<<<< HEAD
    // public Grid gridComponent;
=======
    public Grid gridComponent;

>>>>>>> 2594fe09400e5c977cf6a25d93ee384733f4d1fc
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
<<<<<<< HEAD
        if (playerCurrPos != playerLastPos || Input.GetMouseButton(1))
        { // If the player is moving, disable rendering crosshair.
        // If right click is held (for camera rotation), disable rendering crosshair
=======
        if (playerCurrPos != playerLastPos)
        { // If the player is moving, disable rendering crosshair.
>>>>>>> 2594fe09400e5c977cf6a25d93ee384733f4d1fc
            GetComponent<Renderer>().enabled = false;
            playerLastPos = playerCurrPos;
        } else { 
            // If player is not moving, enable rendering crosshair and show it
            // according to where the mouse is pointing at
            GetComponent<Renderer>().enabled = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitSmth = Physics.Raycast(ray, out RaycastHit hitInfo);
<<<<<<< HEAD

            Vector3 newPos = hitInfo.point;
            newPos.y += 0.01f;

            transform.position = newPos;
=======
            int xCoordGrid = gridComponent.GetX(hitInfo.point);
            int yCoordGrid = gridComponent.GetY(hitInfo.point);
            Vector3 gridCentre = gridComponent.GetWorldPositionCentre(xCoordGrid, yCoordGrid);
            gridCentre.y += 0.01f;
            transform.position = gridCentre;
>>>>>>> 2594fe09400e5c977cf6a25d93ee384733f4d1fc
        }
    }

}
