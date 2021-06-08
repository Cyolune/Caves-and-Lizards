using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** This script encapsulates the camera movement determined by player inputs. 
 *
 * Involves moving via WASD and Edge Panning, middle click to rotate and scroll wheel to zoom.
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
        StartCoroutine(Move());
        StartCoroutine(Rotate());
        StartCoroutine(Zoom());
    }
    
    // Camera movement via WASD and Edge panning
    IEnumerator Move ()
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

        /* Currently Disabled Edge Panning to make game testing easier
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
        */
        yield return null;
    }

    // Middle Mouse Click
    private Vector3 heldPos;
    private Ray ray = new Ray();
    private Plane hPlane = new Plane();
    private Vector3 origFacingDir = new Vector3();
    IEnumerator Rotate()
    {
        if (Input.GetMouseButtonDown(2))
        { // initialise the constants at the point of mouse click
            heldPos = Input.mousePosition;
            ray = new Ray(transform.position, transform.forward);
            hPlane = new Plane(Vector3.up, Vector3.zero);
            origFacingDir = transform.eulerAngles; // facing direction angle in degrees
        }
        if (Input.GetMouseButton(2)) 
        { // change the position and rotation according to mouse movement
            ray = new Ray(transform.position, transform.forward);
            Vector3 newPos = Input.mousePosition;
            float diffInX = (newPos.x - heldPos.x) / 25; // +ve rotate right, also arc length
            
            // Plane.Raycast stores the distance from ray.origin to the hit point in this variable:
            float distance = 0; 
            Vector3 botOfCone = new Vector3();
            // if the ray hits the plane...
            if (hPlane.Raycast(ray, out distance))
            { // get the hit point:
                botOfCone = ray.GetPoint(distance);
            }
            // Basically this just gets the new position of the camera
            Vector3 centerOfBase = new Vector3(botOfCone.x, transform.position.y, botOfCone.z);
            float radius = Vector3.Distance(transform.position, centerOfBase);
            float angle = diffInX / radius - Mathf.PI/2 - origFacingDir.y/180 * Mathf.PI; // arclength-radius angle (in radians)
            transform.position = new Vector3(radius * Mathf.Cos(angle) + centerOfBase.x, transform.position.y, radius * Mathf.Sin(angle) + centerOfBase.z);

            // this rotates the camera with respect to the new position, such that it is still facing the middle.
            transform.eulerAngles = new Vector3(origFacingDir.x, origFacingDir.y - diffInX / radius * 180 / Mathf.PI  ,origFacingDir.z);
        }
        yield return null;
    }
    
    // Scroll wheel with zoom of y=2 to y=10
    IEnumerator Zoom ()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (transform.position.y > 2 && scroll > 0) transform.position += transform.forward;
        if (transform.position.y < 10 && scroll < 0) transform.position -= transform.forward;
        yield return null;
    }
}
