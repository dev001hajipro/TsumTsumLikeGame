using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectingAnimalBallsManagerBehaviour : MonoBehaviour {

    private List<GameObject> selectingBalls;

    public bool IsSelecting { get; set; }

    void Awake()
    {
        selectingBalls = new List<GameObject>();
    }

    private void Add(GameObject item)
    {
        if (!selectingBalls.Contains(item))
            selectingBalls.Add(item.GetComponent<AnimalBallBehaviour>().DoTransparency(0.5f));
    }
    private bool IsValid(GameObject item)
    {
        if (selectingBalls.Count == 0) return true;
        var mySpriteName = item.GetComponent<SpriteRenderer>().sprite.name;
        return selectingBalls.All(o => o.GetComponent<SpriteRenderer>().sprite.name.Equals(mySpriteName));
    }

    private bool IsScoreing() => IsSelecting && selectingBalls.Count >= 3;

    private int CalcPoint() => selectingBalls.Count * 10;

    private void DestroyAnimalBalls()
    {
        selectingBalls.ForEach(o => Destroy(o));
        selectingBalls.Clear();
    }

    public void StartSelecting(GameObject o)
    {
        IsSelecting = true;
        if (IsValid(o))
            Add(o);
    }

    public void ContinueSelecting(GameObject o)
    {
        if (IsSelecting && IsValid(o))
                Add(o);
    }

    public void StopSelecting()
    {
        Calc();
        ResetBalls();
    }

    private void Calc()
    {
        if (IsScoreing())
        {
            GameObject.Find("ScoreText").GetComponent<ScoreTextBehaviour>().Add(CalcPoint());
            DestroyAnimalBalls();
        }
    }

    private void ResetBalls()
    {
        selectingBalls.ForEach(o => o.GetComponent<AnimalBallBehaviour>().DoTransparency(1f));
        selectingBalls.Clear();
        IsSelecting = false;
    }
}
