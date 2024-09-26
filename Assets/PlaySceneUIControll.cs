using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlaySceneUIControll : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Canvas mainMenuCanvas;
    public Canvas PauseCanvas;
    public Canvas GameLostCanvas;
    private Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
         if (player != null)
        {
            player.OnPlayerDeath += updateLostScene; // Subscribe to the player death event
        }
        else
        {
            Debug.LogError("Player instance is not set.");
        }
        GameLostCanvas.gameObject.SetActive(false); // Hide the Lost canvas initially
    }
    public void OnClickPause()
    {
        PauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnClickUnPause()
    {
        PauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    } 
    public void updateLostScene()
    {
        
        mainMenuCanvas.gameObject.SetActive(false);
        GameLostCanvas.gameObject.SetActive(true);
        
    }
}
