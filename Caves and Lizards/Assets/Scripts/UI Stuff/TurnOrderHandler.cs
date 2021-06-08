using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOrderHandler : MonoBehaviour
{
    private CombatTime CTscript;
    bool isCombatTime;

    public Text turnOrderText;
    public Text popUp;
    private bool hasPoppedUp = false;
    public GameObject endTurnButton;


    // Start is called before the first frame update
    void Start()
    {
        CTscript = transform.parent.GetComponentInParent<CombatTime>();
        popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 0);
        endTurnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isCombatTime = CTscript.isItCombatTime();
        if (isCombatTime) {
            endTurnButton.SetActive(true);
            GameObject currTurnUnit = CTscript.currTurnUnit;
            // Logic for fading the "Its your turn" popup in and out
            // as well as enabling/disabling the endturn button
            if (!hasPoppedUp && currTurnUnit.Equals(CTscript.player)) {
                endTurnButton.GetComponent<Button>().interactable = true;
                hasPoppedUp = true;
                StartCoroutine(FadeText(0.5f, popUp));
            } else if (!currTurnUnit.Equals(CTscript.player)) {
                popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 0);
                hasPoppedUp = false;
                endTurnButton.GetComponent<Button>().interactable = false;
            }
            // Logic for handling the turn order text
            turnOrderText.text = currTurnUnit.name;
            for (int i = (CTscript.currUnitIndex + 1) % CTscript.unitsInCombat; i != CTscript.currUnitIndex; i = (i + 1) % CTscript.unitsInCombat) {
                turnOrderText.text += " | " + CTscript.combatUnitsList[i].name;
            }
        } else {
            // not in combat
            turnOrderText.text = "";
            popUp.color = new Color(popUp.color.r, popUp.color.g, popUp.color.b, 0);
            hasPoppedUp = false;
            endTurnButton.SetActive(false);
        }
    }
    public IEnumerator FadeText(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        yield return new WaitForSeconds(1.5f);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        yield return null;
    }
}
