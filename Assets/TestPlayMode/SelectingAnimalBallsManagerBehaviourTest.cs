using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SelectingAnimalBallsManagerBehaviourTest
{
    [SetUp]
    public void Setup()
    {

    }

	[Test]
	public void StartSelecting() {
        var o = new GameObject("SelectingAnimalBallsManager");
        var script = o.AddComponent<SelectingAnimalBallsManagerBehaviour>();
        Debug.Log(GameObject.Find("SelectingAnimalBallsManager"));

        var ball1 = new GameObject("ball1");
        ball1.AddComponent<SpriteRenderer>();
        script.StartSelecting(ball1);

        Assert.AreEqual(true, script.IsSelecting);
     }

    [Test]
    public void StopSelecting()
    {
        var o = new GameObject("SelectingAnimalBallsManager");
        var script = o.AddComponent<SelectingAnimalBallsManagerBehaviour>();

        script.StopSelecting();

        Assert.AreEqual(false, script.IsSelecting);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator NewPlayModeTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
