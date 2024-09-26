using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[AddComponentMenu("AnhDuy/StartMenuControl")]
public class StartMenuControl : MonoBehaviour
{
    // References to the canvases
    public Canvas mainMenuCanvas;
    public Canvas settingsCanvas;
    public Canvas modeCanvas;

    public void OnClickStart()
    {
        // Load the SampleScene and disable the MainMenu scene
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickSettings()
    {
        // Enable Settings canvas and disable StartMenu canvas
        if (settingsCanvas != null && mainMenuCanvas != null)
        {
            settingsCanvas.gameObject.SetActive(true);
            mainMenuCanvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Canvases are not assigned in the inspector.");
        }
    }

    public void OnClickMode()
    {
        // Enable Mode canvas and disable StartMenu canvas
        if (modeCanvas != null && mainMenuCanvas != null)
        {
            modeCanvas.gameObject.SetActive(true);
            mainMenuCanvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Canvases are not assigned in the inspector.");
        }
    }

    public void OnClickExit()
    {
        // Exit the application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // This will stop the play mode in the editor
#else
        Application.Quit(); // This will quit the application when built
#endif
    }
}
