using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeMenuControll : MonoBehaviour
{
   public Canvas mainMenuCanvas;
    public Canvas modeCanvas;
     public void OnClickBack()
    {
        // Enable Settings canvas and disable StartMenu canvas
        if (modeCanvas != null && mainMenuCanvas != null)
        {
            modeCanvas.gameObject.SetActive(false);
            mainMenuCanvas.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Canvases are not assigned in the inspector.");
        }
    }
}
