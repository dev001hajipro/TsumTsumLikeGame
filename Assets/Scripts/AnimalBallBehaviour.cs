using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimalBallBehaviour : MonoBehaviour,
    IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    private SelectedTargetManager mgr;

    private void Awake()
    {
        mgr = GameObject.Find("SelectedTargetManager").GetComponent<SelectedTargetManager>();
    }

    #region IPointer Handlers
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Reset Mgr.List mgr.Clear()");
        mgr.Clear();
        mgr.IsSelecting = true;
        if (mgr.IsValid(this.gameObject))
        {
            Debug.Log("Added gameobject by OnPointerDown ");
            mgr.Add(this.gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        if (mgr.IsSelecting)
        {
            Debug.Log("OnPointerEnter isSelecting");
            if (mgr.IsValid(this.gameObject))
            {
                Debug.Log("Added gameobject by OnPointerEnter");
                mgr.Add(this.gameObject);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (mgr.IsScoreing())
        {
            // もし妥当なら削除して得点。
            mgr.CalcPoint();
            mgr.DestroyAnimalBalls();
            Debug.Log("DestroyAnimalBalls!!");
        }
        mgr.Clear();
        mgr.IsSelecting = false;
    }
    #endregion
}
