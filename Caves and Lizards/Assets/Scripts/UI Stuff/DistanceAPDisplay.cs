using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DistanceAPDisplay : MonoBehaviour
{
    private CombatTime CTscript;
    bool isCombatTime;
    public GameObject theDisplay;

    // Start is called before the first frame update
    void Start()
    {
        CTscript = transform.parent.GetComponentInParent<CombatTime>();
        theDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isCombatTime = CTscript.isItCombatTime();
        if (isCombatTime && CTscript.player == CTscript.currTurnUnit)
        {
            theDisplay.SetActive(true);
            Vector3 mousePos = Input.mousePosition;
            theDisplay.transform.position = mousePos;
        }
        else // not combat time or not player's turn
        {
            theDisplay.SetActive(false);
        }
    }

    public void updateText(float dist, float APCost)
    {
        String num = Math.Round(dist, 1).ToString();
        if (num.Length == 1)
        {
            num += ".0";
        }
        theDisplay.GetComponent<Text>().text = num + "m\n" + APCost + " AP";
    }
}
