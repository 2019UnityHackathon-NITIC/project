using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour
{
    [SerializeField] private Text pointCounter;
    private List<int> _pointCache = new List<int>();

    private void Start()
    {
        if (pointCounter != null)
        {
            pointCounter.text = "CleanEnergy : " + Parameters.CleanEnergy.ToString() + "\nUnCleanEnergy : " +
                                Parameters.UnCleanEnergy.ToString();
            _pointCache.Add(Parameters.CleanEnergy);
            _pointCache.Add(Parameters.UnCleanEnergy);
        }
    }

    private void Update()
    {
        if (_pointCache[0] != Parameters.CleanEnergy || _pointCache[1] != Parameters.UnCleanEnergy)
        {
            pointCounter.text = "CleanEnergy : " + Parameters.CleanEnergy.ToString() + "\nUnCleanEnergy : " +
                                Parameters.UnCleanEnergy.ToString();
            _pointCache[0] = Parameters.CleanEnergy;
            _pointCache[1] = Parameters.UnCleanEnergy;
        }
    }
}
