using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsNS;

public class EnemyStat : MonoBehaviour, StatInterface
{
    Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        float[] temp = {1, 1, 1, 1, 1, 1};
        stats = new Stats(temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
