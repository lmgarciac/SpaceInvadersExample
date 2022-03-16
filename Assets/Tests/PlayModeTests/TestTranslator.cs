using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestTranslator
{

    GameObject go;
    Rigidbody2D rb;
    Translator trans;
    Vector3 oldPos;

    [SetUp]
    public void Setup()
    {
        go = new GameObject();
        rb = go.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        trans = go.AddComponent<Translator>();
        oldPos = go.transform.position;
        rb.isKinematic = true;
    }

    [UnityTest]
    public IEnumerator GivenZeroMovementVectorTheGameObjectStaysInPlace()
    {
        yield return null; //Wait for Start Event

        trans.Move(Vector2.zero);

        yield return new WaitForSeconds(1f); //Allow for velocity to take place

        Assert.AreEqual(oldPos, go.transform.position);
    }

    [UnityTest]
    public IEnumerator GivenNonZeroMovementVectorTheGameObjectMovesAsExpected()
    {
        yield return null; //Wait for Start Event

        trans.Move(Vector2.right);

        yield return new WaitForSeconds(1f); //Allow for velocity to take place

        Assert.AreEqual(oldPos.y, go.transform.position.y);
        Assert.IsTrue(Mathf.Approximately(1f, go.transform.position.x), "transform.position.x is not 1f as expected");
    }

    [UnityTest]
    public IEnumerator GivenDiagonalMovementVectorTheGameObjectMovesAsExpected()
    {
        yield return null; //Wait for Start Event

        trans.Move(new Vector2(1f,1f));

        yield return new WaitForSeconds(1f); //Allow for velocity to take place

        Assert.IsTrue(Mathf.Approximately(1f, go.transform.position.y), "transform.position.y is not 1f as expected");
        Assert.IsTrue(Mathf.Approximately(1f, go.transform.position.x), "transform.position.x is not 1f as expected");
    }

    [UnityTest]
    public IEnumerator GivenInitialSpeedTheGameObjectReducesSpeedOverTime()
    {
        yield return null; //Wait for Start Event

        trans.Move(new Vector2(1f, 1f));

        yield return new WaitForSeconds(1f); //Allow for velocity to take place

        trans.Stop();

        yield return new WaitForSeconds(1f); //Allow for velocity to diminish

        Assert.IsTrue(Mathf.Approximately(0f, rb.velocity.y), $"rb.velocity.y is not 0f as expected but {rb.velocity.y}");
        Assert.IsTrue(Mathf.Approximately(0f, rb.velocity.x), $"rb.velocity.x is not 0f as expected but {rb.velocity.x}");
    }
}
