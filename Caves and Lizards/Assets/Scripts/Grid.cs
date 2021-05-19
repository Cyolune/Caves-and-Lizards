using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private int cellSize;
    [SerializeField] private Vector3 leftBotCorner;
    private Vector3[,] gridCentreArray;

    // The player in the game
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 playerStartPos;
    [SerializeField] private UnityEngine.AI.NavMeshAgent playerNavAgent;
    [SerializeField] private Camera cam;

    /**
    public Grid(int width, int height, int cellSize, Vector3 leftBotCorner) 
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.leftBotCorner = leftBotCorner;

        gridCentreArray = new Vector3[width,height];

        for (int x = 0; x < width; x ++) {
            for (int y = 0; y < height; y++) {
                // Draw white lines around each grid
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);

                // Centre point of each grid
                gridCentreArray[x,y] = new Vector3(GetWorldPosition(x, y).x + cellSize / 2f, 
                    leftBotCorner.y, 
                    GetWorldPosition(x, y).z + cellSize / 2f);

                
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }
    */

    void Start() 
    {   
        gridCentreArray = new Vector3[height, width];
        InitializeGrid();
        player.transform.position = playerStartPos;
    }

    // Get world position of bottem left corner of grid with x and y coordinates
    public Vector3 GetWorldPosition(int x, int y) 
    {
        return new Vector3(x, leftBotCorner.y, y) * cellSize + leftBotCorner;
    }

    public Vector3 GetWorldPositionCentre(int x, int y) 
    {
        return gridCentreArray[x,y];
    }

    // Get X coordinate of bottom left corner of grid containing the world position within it
    public int GetX(Vector3 worldPosition) {
        return Mathf.FloorToInt((worldPosition - leftBotCorner).x / cellSize);
    }

    // Get Y coordinate of bottom left corner of grid containing the world position within it
    public int GetY(Vector3 worldPosition) {
        return Mathf.FloorToInt((worldPosition - leftBotCorner).z / cellSize);
    }

    private void InitializeGrid() 
    {
        for (int x = 0; x < width; x ++) {
            for (int y = 0; y < height; y++) {
                // Draw white lines around each grid
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);

                // Centre point of each grid
                gridCentreArray[x,y] = new Vector3(GetWorldPosition(x, y).x + cellSize / 2f, 
                    leftBotCorner.y, 
                    GetWorldPosition(x, y).z + cellSize / 2f);

                
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }
}
