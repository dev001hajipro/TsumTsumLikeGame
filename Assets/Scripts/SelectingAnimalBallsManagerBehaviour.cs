using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectingAnimalBallsManagerBehaviour : MonoBehaviour {

    private List<GameObject> removeTargetObjects;

    public bool IsSelecting { get; set; }

    void Awake()
    {
        removeTargetObjects = new List<GameObject>();
    }

    private void Init()
    {
        removeTargetObjects.Clear();
        IsSelecting = false;
    }

    private void Add(GameObject item)
    {
        if (!removeTargetObjects.Contains(item))
            removeTargetObjects.Add(item);
    }
    private bool IsValid(GameObject item)
    {
        if (removeTargetObjects.Count == 0) return true;
        var mySpriteName = item.GetComponent<SpriteRenderer>().sprite.name;
        return removeTargetObjects.All(o => o.GetComponent<SpriteRenderer>().sprite.name.Equals(mySpriteName));
    }

    private bool IsScoreing() => IsSelecting && removeTargetObjects.Count >= 3;

    private int CalcPoint() => removeTargetObjects.Count * 10;

    private void DestroyAnimalBalls() => removeTargetObjects.ForEach(o => Destroy(o));

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
