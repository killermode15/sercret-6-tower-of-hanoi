using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RingManager : MonoBehaviour
{

    [Header("Ring Properties")]
    //[SerializeField] private RingColorPalette colorPalette;
    //[SerializeField] private int ringCount = 4;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private GameObject ringPrefab;
    [SerializeField] private RodHandler startingRod;


    private List<Ring> spawnedRings = new List<Ring>();
    
    public void SetupRings()
    {
        Transform ringStartPoint = startingRod.transform.GetChild(0);
        Vector3 ringPosition = ringStartPoint.position;
        List<Vector3> ringPositions = new List<Vector3>();

        for (int i = gameSettings.NumberOfRings - 1; i >= 0; i--)
        {
            GameObject ring = Instantiate(ringPrefab, ringStartPoint.position, Quaternion.identity);

            ring.GetComponent<SpriteRenderer>().color = gameSettings.ColorPalette.GetColor(i);

            Ring ringScript = ring.GetComponent<Ring>();
            ringScript.SetRing(i + 1);
            ring.transform.localScale += new Vector3(0.5f * (i), 0, 0);


            spawnedRings.Add(ringScript);
        }

        foreach (Ring ring in spawnedRings)
        {
            startingRod.AddRingToRod(ring, true);
        }
    }
}
