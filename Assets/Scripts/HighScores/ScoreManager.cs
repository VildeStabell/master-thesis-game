using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public ScoreData sd;
    public RoundController roundController;

    public void getScoresFromJson() {
        var json = PlayerPrefs.GetString(roundController.GetGameMode().getName() + "scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores() {
        return roundController.GetGameMode().getSortedScores(sd);
    }

    public void AddScore(Score score) {
        sd.scores.Add(score);
    }

    private void OnDestroy() {
        SaveScore();
    }

    public void SaveScore() {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString(roundController.GetGameMode().getName() + "scores", json);
    }


}
