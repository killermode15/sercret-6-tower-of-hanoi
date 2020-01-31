using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameSettings gameSettings = null;
    [SerializeField] private TMP_Dropdown dropdownUI = null;
    [SerializeField] private TextMeshProUGUI ringCountText = null;
    [SerializeField] private Toggle showRingNumberToggle = null;
    [SerializeField] private GameObject settingsPanel = null;

    [Header("Colour Settings")]
    [Space(10)]
    [SerializeField] private List<RingColorPalette> colorPalettes = new List<RingColorPalette>();

    private bool showSettings = false;

    private void OnEnable()
    {
        int currentPaletteIndex = colorPalettes.FindIndex(x => x == gameSettings.ColorPalette);
        dropdownUI.value = currentPaletteIndex;
        ringCountText.text = gameSettings.NumberOfRings.ToString();
        showRingNumberToggle.isOn = gameSettings.ShowRingNumber;
        settingsPanel.SetActive(showSettings);
    }

    public void ChangeColourPalettes(int i)
    {
        gameSettings.ChangeColorPalette(colorPalettes[i]);
    }

    public void UpdateRingCountText()
    {
        ringCountText.text = gameSettings.NumberOfRings.ToString();
    }

    public void ToggleSettings()
    {
        showSettings = !showSettings;
        settingsPanel.SetActive(showSettings);
    }
}