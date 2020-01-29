using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private TMP_Dropdown dropdownUI;

    [Header("Colour Settings")]
    [Space(10)]
    [SerializeField] private List<RingColorPalette> colorPalettes;


    private void OnEnable()
    {
        int currentPaletteIndex = colorPalettes.FindIndex(x => x == gameSettings.ColorPalette);
        dropdownUI.value = currentPaletteIndex;
    }

    public void ChangeColourPalettes(int i)
    {
        gameSettings.ChangeColorPalette(colorPalettes[i]);
    }
}