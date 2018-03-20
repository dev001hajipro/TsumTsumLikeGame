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

    private void Init()
    {
        selectingBalls.ForEach(o => DoTransparency(o, 1f));
        selectingBalls.Clear();
        IsSelecting = false;
    }

    private void Add(GameObject item)
    {
        if (!selectingBalls.Contains(item))
            selectingBalls.Add(DoTransparency(item, 0.5f));
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

    // TODO animalballへ透過イベントを送り処理すべき?
    private GameObject DoTransparency(GameObject o, float alpha = 1f)
    {
        Color c = o.GetComponent<SpriteRenderer>().color;
        c.a = alpha;
        o.GetComponent<SpriteRenderer>().color = c;
        return o;
    }

    public void StartSelecting(GameObject o)
    {
        Init();
        IsSelecting = true;
        if (IsValid(o))
            Add(o);
    }

    public void ContinueSelecting(GameObject o)
    {
        if (IsSelecting && IsValid(o))
                Add(o);
    }

    public SelectingAnimalBallsManagerBehaviour Calc()
    {
        if (IsScoreing())
        {
            CalcPoint();
            DestroyAnimalBalls();
        }
        return this;
    }
    public void StopSelecting()
    {
        Init();
    }
}
