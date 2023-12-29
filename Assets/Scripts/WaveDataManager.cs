using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.UniversalVehicleCombat;

public class WaveDataManager : MonoBehaviour
{
    public static WaveDataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int waveCount = 0;
}
