using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RingColorPalette : ScriptableObject
{
    [SerializeField] private List<Color> ringColorPalette = new List<Color>();

    public Color GetColor(int index) => ringColorPalette[index];
}
