using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    [SerializeField] private LevelFiller levelFiller;
    [SerializeField] private Canvas gameplayCanvas;
    [SerializeField] private Canvas endgameCanvas;
    [SerializeField] private Text potionsText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text coinsToCollectText;
    [SerializeField] private Text healthText;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private PlayerController player;
    

    private int levelChosed;
    private void Start()
    {
        gameplayCanvas.enabled = true;
        endgameCanvas.enabled = false;
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MenuScene");
        
    }


    public void NextLevel()
    {
        GameController.Instance.NextLevel();
        GameController.Instance.StartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameplayCanvas.enabled = true;
        endgameCanvas.enabled = false;
    }
    
    private void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
        gameplayCanvas.enabled = true;
        endgameCanvas.enabled = false;
        inventory = GameController.Instance.Player.GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (inventory != null)
        {
            potionsText.text = GameController.Instance.PotionsInBag.ToString();
            coinsText.text = GameController.Instance.CoinsInBag.ToString();
            coinsToCollectText.text = GameController.Instance.CoinsToCollect.ToString();
            healthText.text = GameController.Instance.CurrentHealts.ToString();
        }

        if (!GameController.Instance.isPlaying)
        {
            endgameCanvas.enabled = true;
            gameplayCanvas.enabled = false;
        }
        
    }
}
