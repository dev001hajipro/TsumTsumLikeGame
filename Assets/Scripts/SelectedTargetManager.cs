using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SelectedTargetManager : MonoBehaviour {

    private List<GameObject> removeTargetObjects;

    public bool IsSelecting { get; set; }


    void Start () {
        removeTargetObjects = new List<GameObject>();
	}

    public void CreateList()
    {
        removeTargetObjects.Clear();
    }

    public void Add(GameObject item)
    {
        if (!removeTargetObjects.Contains(item))
            removeTargetObjects.Add(item);
    }
    public bool IsValid(GameObject item)
    {
        if (removeTargetObjects.Count == 0)
            return true;

        var spriteName = removeTargetObjects.First().GetComponent<SpriteRenderer>().sprite.name;
        return removeTargetObjects.All(o => o.GetComponent<SpriteRenderer>().sprite.name.Equals(spriteName));
    }

    public bool IsScoreing() => IsSelecting && removeTargetObjects.Count >= 3;

    public int CalcPoint() => removeTargetObjects.Count * 10;

    public void DestroyAnimalBalls()
    {
        removeTargetObjects.ForEach(o => Destroy(o));
    }

    public void Clear()
    {
        removeTargetObjects.Clear();
    }
}
