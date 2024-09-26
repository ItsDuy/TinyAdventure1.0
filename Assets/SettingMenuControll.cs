using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenuControll : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas mainMenuCanvas;
    public Canvas settingsCanvas;
     public void OnClickBack()
    {
        // Enable Settings canvas and disable StartMenu canvas
        if (settingsCanvas != null && mainMenuCanvas != null)
        {
            settingsCanvas.gameObject.SetActive(false);
            mainMenuCanvas.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Canvases are not assigned in the inspector.");
        }
    }
}
