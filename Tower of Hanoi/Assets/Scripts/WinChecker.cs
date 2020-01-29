using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    [SerializeField] private RingManager ringManager;
    [SerializeField] private RodHandler goalRod;

    private void Update()
    {
        Win();
    }

    private void Win()
    {
        if (goalRod.RingCount == ringManager.RingCount)
        {
            Debug.Log("Win");
        }
    }
}
