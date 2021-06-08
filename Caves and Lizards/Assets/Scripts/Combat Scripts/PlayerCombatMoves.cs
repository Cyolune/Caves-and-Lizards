using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombatMoves : MonoBehaviour
{   
    /*
    public PlayerProperties playerStat;
    public Transform atkCentre;
    public float atkRange = 0.5f;
    public LayerMask Enemy;
    */
    public GameObject AttackActionHandler;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Attack() 
    {
        AttackActionHandler.SetActive(true);
        
        /*
        // Detect enemies in range of atk
        Collider[] enemiesHit = Physics.OverlapSphere(atkCentre.position, atkRange, Enemy);

        //Deal damage to enemies hit
        foreach (var enemy in enemiesHit) {
            StatInterface enemyStat = enemy.GetComponent<StatInterface>();
            enemyStat.takeDamage(10);
        }
        */
    }
}
