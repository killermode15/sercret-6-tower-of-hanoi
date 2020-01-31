using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameSettings : ScriptableObject
{
    public bool ShowRingNumber => showRingNumber;
    public int NumberOfRings => numberOfRings;
    public RingColorPalette ColorPalette => colorPalette;
    public AnimationCurve RingEaseCurve => easeCurve;

    [Header("Rings Settings")]
    [SerializeField] private int numberOfRings = 4;
    [SerializeField] private bool showRingNumber = true;
    [SerializeField] private Vector2Int ringLimit;

    [Header("Aesthetic Settings")]
    [Space(10)]
    [SerializeField] private RingColorPalette colorPalette = null;
    [SerializeField] private AnimationCurve easeCurve = null;

    private void OnValidate()
    {
        if (ringLimit.x < 3)
            ringLimit.x = 3;
        if (ringLimit.y > 8)
            ringLimit.y = 8;

        numberOfRings = Mathf.Clamp(numberOfRings, ringLimit.x, ringLimit.y);
    }

    public void ChangeColorPalette(RingColorPalette newPalette)
    {
        if (newPalette != null && colorPalette == newPalette)
        {
            return;
        }

        colorPalette = newPalette;
    }

    public void AddRing()
    {
        numberOfRings++;
        if (numberOfRings > ringLimit.y)
            numberOfRings = ringLimit.y;
    }

    public void ReduceRing()
    {
        numberOfRings--;
        if (numberOfRings < ringLimit.x)
            numberOfRings = ringLimit.x;
    }



    public void ToggleRingNumber(bool val)
    {
        showRingNumber = val;
    }
}