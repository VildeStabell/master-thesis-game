using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public TMP_Text title;
    public TMP_Text description;
    public GameObject mainMenuButtons;
    public GameObject gameModeDetails;
    public Button primaryButton;
    public Button playButton;

    private GameModeEnum chosenGameMode;

    public void balanceModeButtonPressed() {
        chosenGameMode = GameModeEnum.BalanceMode;
        openGameDetails(new BalanceMode(null));
    }

    public void backButtonPressed() {
        gameModeDetails.SetActive(false);
        mainMenuButtons.SetActive(true);
        primaryButton.Select();
    }

    public void Start() {
        gameModeDetails.SetActive(false);
        mainMenuButtons.SetActive(true);
    }

    public void PlayButtonPressed() {
        switch(chosenGameMode) {
            case GameModeEnum.BalanceMode:
                SceneManager.LoadScene (sceneName:"BalanceScene");
                break;
        }
    }

    // ---- Utility functions ----
    
    void openGameDetails(GameMode gameMode) {
        mainMenuButtons.SetActive(false);
        gameModeDetails.SetActive(true);
        title.text = gameMode.getName();
        description.text = gameMode.getDescription();
        playButton.Select();
    }
}
