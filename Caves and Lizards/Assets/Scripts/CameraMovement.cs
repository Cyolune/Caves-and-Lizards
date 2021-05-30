using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This script encapsulates the camera movement determined by player inputs. 
 *
 * Involves moving via WASD and Edge Panning, right click to rotate and scroll wheel to zoom.
 */
public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        Move();
        Rotate();
        Zoom();
    }
    
    // Camera movement via WASD and Edge panning
    void Move ()
    {
        // WASD movement
        float WS = Input.GetAxis("Vertical");
        float DA = Input.GetAxis("Horizontal");
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        forward.y = 0;
        right.y = 0;
        if (WS != 0) transform.position += forward * WS / 50;
        if (DA != 0) transform.position += right * DA  / 50;

        /* Currently Disabled Edge Panning to make game testing easier */
        // Edge Panning
        // Left-Right
        if (Input.mousePosition.x >= Screen.width) {
            transform.position += right / 50;
        } else if (Input.mousePosition.x <= 0) {
            transform.position -= right / 50;
        }
        // Up-Down
        if (Input.mousePosition.y >= Screen.height) {
            transform.position += forward / 50;
        } else if (Input.mousePosition.y <= 0) {
            transform.position -= forward / 50;
        }
        /**/
    }

    // Right Click and hold for >0.15s
    private Vector3 heldPos;
    private float startHeldTime;
    void Rotate ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            startHeldTime = Time.time;
        }
        if (Input.GetMouseButton(1)) 
        {
            if (Time.time - startHeldTime < 0.15) return;
            if (Time.time - startHeldTime < 0.16) 
            {
                heldPos = Input.mousePosition;
                return;
            }
            Vector3 newPos = Input.mousePosition;
            Vector3 diff = newPos - heldPos; // +ve rotate right
            transform.Rotate(new Vector3(0,1,0), diff.x / 2, Space.World);
            heldPos = newPos;
        }
    }
    
    // Scroll wheel with zoom of y=2 to y=10
    void Zoom ()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (transform.position.y > 2 && scroll > 0) transform.position += transform.forward;
        if (transform.position.y < 10 && scroll < 0) transform.position -= transform.forward;
    }
}
