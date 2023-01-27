using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
    {
        public void LoadStartScene()
        {
            SceneManager.LoadScene("StartGameScene");
        }
        
        public void LoadGameScene()
        {
            SceneManager.LoadScene("GameScene");
        }
        public void LoadWinScene()
        {
            SceneManager.LoadScene("WinScene");
          
        }
        public void LoadGameOverScene()
        {
            SceneManager.LoadScene("GameOverScene");
          
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
