using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackActionHandler : MonoBehaviour
{
    public Button attkButton;
    public GameObject crosshair;
    public GameObject player;
    // Start is called before the first frame update
    private bool resetted = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!resetted) {
            attkButton.interactable = false;
            crosshair.GetComponent<CrosshairMovement>().disableCHRendering();
            player.GetComponent<NavMeshCharacter>().canMove = false;
            resetted = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            finishAction();
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hitSmth = Physics.Raycast(ray, out RaycastHit hitInfo);
        if (hitSmth && Input.GetMouseButtonDown(0))
        {
            GameObject hitGameObject = hitInfo.transform.gameObject;
            if (hitGameObject.GetComponent<isEnemy>() != null) 
            {   // object hit is enemy
                Debug.Log("Enemy hit for 5 damage!");
                hitGameObject.GetComponent<StatInterface>().getStats().takeDmg(5);
                finishAction();
            }
            
        }
    }

    public void finishAction() {
        attkButton.interactable = true;
        player.GetComponent<NavMeshCharacter>().canMove = true;
        crosshair.GetComponent<CrosshairMovement>().enableCHRendering();
        resetted = false;
        this.gameObject.SetActive(false);
    }
}
