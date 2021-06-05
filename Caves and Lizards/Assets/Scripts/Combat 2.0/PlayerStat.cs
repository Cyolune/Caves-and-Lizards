using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsNS;

public class PlayerStat2 : MonoBehaviour, StatInterface
{
    Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        float[] temp = {10, 10, 10, 10, 10, 10};
        stats = new Stats(temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
