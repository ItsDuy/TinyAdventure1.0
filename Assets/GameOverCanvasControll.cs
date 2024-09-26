using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverCanvasControll : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas GameLostCanvas;
    public Transform spawnPoint;
    private Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    public void OnClickReplay()
    {
        GameLostCanvas.gameObject.SetActive(false); // Hide the Lost canvas
        mainMenuCanvas.gameObject.SetActive(true);
         if (player != null)
        {
           player.ResetPlayer(spawnPoint.position); 
        }
        else
        {
            Debug.LogError("Player instance is not found on replay.");
        }
        
    }
    public void OnClickExit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // This will stop the play mode in the editor
#else
        Application.Quit(); // This will quit the application when built
#endif
    } 
   
}
