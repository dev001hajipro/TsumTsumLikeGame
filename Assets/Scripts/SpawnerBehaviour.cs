using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnerBehaviour : MonoBehaviour
{
    public GameObject ballPrefab;
    public Sprite[] sprites;

    void Start()
    {
        StartCoroutine(Spawn(50));
    }

    IEnumerator Spawn(int count)
    {
        Enumerable.Range(0, count).Select(_ => CreateBall()).ToList();
        yield return new WaitForSeconds(0.1f);
    }

    private GameObject CreateBall()
    {
        var o = Instantiate(ballPrefab, new Vector2(Random.Range(-2.0f, 2.0f), 7f), Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward), gameObject.transform);
        o.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        return o;
    }

    public void ReSpawn()
    {
        DestroyChildren();
        StartCoroutine(Spawn(50));
    }

    private void DestroyChildren() => transform.Cast<Transform>().ToList().ForEach(t => Destroy(t.gameObject));
}
