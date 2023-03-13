using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreData {
    public List<Score> scores;

    public ScoreData() {
        scores = new List<Score>();
    }

}

public class ScoreManager : MonoBehaviour {
    public ScoreData sd;
    public RoundController roundController;
    public GameObject scoresUI;
    public GameObject scoreContent;
    public RowUI rowUI;

    public void getScoresFromJson() {
        var json = PlayerPrefs.GetString(roundController.GetGameMode().getName() + "scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores() {
        return roundController.GetGameMode().getSortedScores(sd);
    }

    public void AddScore(Score score) {
        sd.scores.Add(score);
        if (sd.scores.Count() > 10) {
            IEnumerable<Score> sortedScores = roundController.GetGameMode().getSortedScores(sd);
            sd.scores.Remove(sortedScores.Last());
        }
    }

    private void OnDestroy() {
        SaveScore();
    }

    public void SaveScore() {

        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString(roundController.GetGameMode().getName() + "scores", json);
    }

    public void showHighScores() {

        scoresUI.SetActive(true);
        var scores = GetHighScores().ToArray();
        for (int i = 0; i < scores.Length && i < 3; i++) {
            var row = Instantiate(rowUI, scoreContent.transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.highScoreName.text = scores[i].highScoreName;
            row.score.text = scores[i].score.ToString();
        }
    }


}
