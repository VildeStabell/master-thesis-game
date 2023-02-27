using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour {
    public RowUI rowUI;
    public ScoreManager scoreManager;

    void Start() {


        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++) {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.highScoreName.text = scores[i].highScoreName;
            row.score.text = scores[i].score.ToString();
        }
    }
}
