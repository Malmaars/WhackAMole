using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreView : MonoBehaviour, IHighScoreView
{
    public bool active { get; set; }
    public GameObject[] Visuals { get { return visuals; } set { visuals = value; } }
    public GameObject[] visuals;

    public RectTransform Content { get { return content; } set { content = value; } }
    public RectTransform content;

    public HighScoreVisualView HighScoreVisualPrefab { get { return highScoreVisualPrefab; } set { highScoreVisualPrefab = value; } }
    public HighScoreVisualView highScoreVisualPrefab;

    int amountOfHighscores;

    public void ClearHighScoreVisuals()
    {
        while(content.childCount > 0)
        {
            Destroy(content.GetChild(0));
        }
    }

    public void AddHighScoreVisual(HighScoreData _highScore)
    {
        HighScoreVisualView temp = Instantiate(highScoreVisualPrefab, content);
        temp.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -1 * amountOfHighscores * highScoreVisualPrefab.GetComponent<RectTransform>().sizeDelta.y);
        amountOfHighscores++;
        content.sizeDelta = new Vector2(content.sizeDelta.x, amountOfHighscores * highScoreVisualPrefab.GetComponent<RectTransform>().sizeDelta.y);

        temp.SetName(_highScore.name);
        temp.SetScore(_highScore.score);
        temp.SetRank(amountOfHighscores);
    }

    public void Enable()
    {
        active = true;
        ShowVisuals();

    }

    public void Disable()
    {
        active = false;
        HideVisuals();
    }

    void ShowVisuals()
    {
        foreach (GameObject ob in Visuals)
        {
            ob.SetActive(true);
        }
    }
    void HideVisuals()
    {
        foreach (GameObject ob in Visuals)
        {
            ob.SetActive(false);
        }
    }
}
