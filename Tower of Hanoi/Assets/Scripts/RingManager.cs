using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    public int RingCount => ringCount;

    [Header("Ring Properties")]
    [SerializeField] private RingColourPalette colourPalette;
    [SerializeField] private int ringCount = 4;
    [SerializeField] private GameObject ringPrefab;
    [SerializeField] private RodHandler startingRod;

    private List<Ring> rings = new List<Ring>();

    private void OnValidate()
    {
        if (ringCount < 3)
            ringCount = 3;
    }

    // Start is called before the first frame update
    void Start()
    {

        Transform ringStartPoint = startingRod.transform.GetChild(0);

        for (int i = ringCount - 1; i >= 0; i--)
        {
            GameObject ring = Instantiate(ringPrefab, ringStartPoint.transform.position, Quaternion.identity);

            ring.GetComponent<SpriteRenderer>().color = colourPalette.GetColor(i);

            Ring ringScript = ring.GetComponent<Ring>();
            ringScript.SetRing(i + 1);
            ring.name = "Ring [" + (i + 1) + "]";
            ring.transform.localScale += new Vector3(0.15f * (i), 0, 0);
            ring.transform.position += new Vector3(0, 0.5f * (ringCount - i -1), 0);
            
            rings.Add(ringScript);
        }

        for (int i = 0; i < rings.Count; i++)
        {
            startingRod.AddRingToRod(rings[i]);
        }


    }
}
