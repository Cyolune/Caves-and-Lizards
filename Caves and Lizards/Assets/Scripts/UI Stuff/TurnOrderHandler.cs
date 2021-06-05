using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOrderHandler : MonoBehaviour
{
    private CombatTime CTscript;
    bool isCombatTime;

    public Text whoseTurn;
    public Text popUp;
    private bool hasPoppedUp = false;
    private float popUpStartTime = 0.0f;
    private bool popUpStartFading = false;

    public GameObject endTurnButton;


    // Start is called before the first frame update
    void Start()
    {
        CTscript = this.GetComponentInParent<CombatTime>();
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 0);
        endTurnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isCombatTime = CTscript.isItCombatTime();
        if (isCombatTime) {
            
            GameObject currTurnUnit = CTscript.currTurnUnit;
            // Logic for fading the "Its your turn" popup in and out
            // as well as enabling/disabling the endturn button
            if (!hasPoppedUp && currTurnUnit.Equals(CTscript.player)) {
                endTurnButton.SetActive(true);
                hasPoppedUp = true;
                popUpStartTime = Time.time;
                StartCoroutine(FadeTextToFullAlpha(0.5f, popUp));
            } else if (hasPoppedUp && !popUpStartFading && Time.time - popUpStartTime > 2) {
                popUpStartFading = true;
                StartCoroutine(FadeTextToZeroAlpha(0.5f, popUp));
            } else if (!currTurnUnit.Equals(CTscript.player)) {
                popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 0);
                hasPoppedUp = false;
                popUpStartFading = false;
                endTurnButton.SetActive(false);
            }
            // Logic for handling the turn order text
            whoseTurn.text = currTurnUnit.name;
            for (int i = (CTscript.currUnitIndex + 1) % CTscript.unitsInCombat; i != CTscript.currUnitIndex; i = (i + 1) % CTscript.unitsInCombat) {
                whoseTurn.text += " | " + CTscript.combatUnitsList[i].name;
            }
        } else {
            // not in combat
            whoseTurn.text = "";
            popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 0);
            hasPoppedUp = false;
            popUpStartFading = false;
            endTurnButton.SetActive(false);
        }
    }
    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        yield return null;
    }
 
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        yield return null;
    }


}
