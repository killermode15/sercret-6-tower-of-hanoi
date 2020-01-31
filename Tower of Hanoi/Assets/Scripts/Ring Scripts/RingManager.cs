using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RingManager : MonoBehaviour
{

    [Header("Ring Properties")]
    [SerializeField] private GameSettings gameSettings = null;
    [SerializeField] private GameObject ringPrefab = null;
    [SerializeField] private RodHandler startingRod = null;

    [Header("References")]
    [Space(10)]
    [SerializeField] private List<RodHandler> rods = new List<RodHandler>();

    private List<Ring> spawnedRings = new List<Ring>();
    
    public void SetupRings()
    {
        Vector3 ringStartPos = startingRod.StartPosition;
        List<Vector3> ringPositions = new List<Vector3>();

        for (int i = gameSettings.NumberOfRings - 1; i >= 0; i--)
        {
            GameObject ring = Instantiate(ringPrefab, ringStartPos, Quaternion.identity);
            Ring ringScript = ring.GetComponent<Ring>();

            Color ringColor = gameSettings.ColorPalette.GetColor(i);
            Vector3 scale = new Vector3(0.5f * (i), 0, 0);

            ringScript.SetRing(i + 1, ringColor, scale, gameSettings.ShowRingNumber);
            spawnedRings.Add(ringScript);
        }

        foreach (Ring ring in spawnedRings)
        {
            startingRod.AddRingToRod(ring, true);
        }
    }

    public void CleanUpRings()
    {
        // Delete all rings and clean it up
        foreach(RodHandler rod in rods)
        {
            rod.ClearRod();
        }
        for (int i = spawnedRings.Count - 1; i  >= 0 ; i--)
        {
            Ring ring = spawnedRings[i];
            spawnedRings.Remove(ring);
            Destroy(ring.gameObject);
        }
    }
}
