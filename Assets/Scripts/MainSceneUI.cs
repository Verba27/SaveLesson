using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour
{
    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Canvas mainMenuCanvas;

    private int levelChosed;
    
    public void StartFirstLevel()
    {
        GameController.Instance.LevelToPlay = 0;
        PlayGame();
    }


    public void StartSecondLevel()
    {
        GameController.Instance.LevelToPlay = 1;
        PlayGame();
    }
    
    private void PlayGame()
    {
        GameController.Instance.StartGame();
        SceneManager.LoadScene("GameScene");
        
    }

    public void LoadGame()
    {
        GameController.Instance.LoadData();
    }

    
}