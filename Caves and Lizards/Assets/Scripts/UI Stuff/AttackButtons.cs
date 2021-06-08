using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButtons : MonoBehaviour
{   
    private CombatTime CTscript;
    bool isCombatTime;
    public GameObject atkButton;
    private Button buttonComponent;
    private bool hasSetInteractable = false;
    // Start is called before the first frame update
    void Start()
    {
        CTscript = transform.parent.GetComponentInParent<CombatTime>();
        atkButton.SetActive(false);
        buttonComponent = atkButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    { 
        isCombatTime = CTscript.isItCombatTime();
        if (isCombatTime)
        {
            atkButton.SetActive(true);
            if (!hasSetInteractable) 
            {
                if (CTscript.currTurnUnit == CTscript.player)
                {
                    buttonComponent.interactable = true;
                    hasSetInteractable = true;
                }
                else // not player's turn
                {
                    buttonComponent.interactable = false;
                }
            }
            else // has been set as interactable already
            {
                if (CTscript.currTurnUnit != CTscript.player)
                {
                    buttonComponent.interactable = false;
                    hasSetInteractable = false;
                }
            }
        }
        else // not combattime
        {
            atkButton.SetActive(false);
        }
    }

    public void changeInteractableState() {
        hasSetInteractable = !hasSetInteractable;
    }

    
}
