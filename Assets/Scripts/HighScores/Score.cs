using System;

[Serializable]
public class Score {
    public string highScoreName;
    public float score;

    public Score(string highScoreName, float score) {
        this.highScoreName = highScoreName;
        this.score = score;
    }
}
