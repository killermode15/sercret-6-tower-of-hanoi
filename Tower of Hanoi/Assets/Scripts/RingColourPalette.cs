using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RingColourPalette : ScriptableObject
{
    [SerializeField] private List<Color> ringColorPalette;

    public Color GetColor(int index) => ringColorPalette[index];
}
