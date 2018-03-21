using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimalBallBehaviour : MonoBehaviour,
    IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    private SelectingAnimalBallsManagerBehaviour manager;

    private void Awake()
    {
        manager = GameObject.Find("SelectingAnimalBallsManager").GetComponent<SelectingAnimalBallsManagerBehaviour>();
    }

    #region IPointer Handlers
    public void OnPointerDown(PointerEventData eventData)
    {
        manager.StartSelecting(eventData.pointerCurrentRaycast.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        manager.ContinueSelecting(eventData.pointerCurrentRaycast.gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        manager.StopSelecting();
    }
    #endregion

    public GameObject DoTransparency(float alpha = 1f)
    {
        Color c = GetComponent<SpriteRenderer>().color;
        c.a = alpha;
        GetComponent<SpriteRenderer>().color = c;
        return gameObject;
    }
}
