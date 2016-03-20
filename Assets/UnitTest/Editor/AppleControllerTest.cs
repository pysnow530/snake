using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class AppleControllerTest {

    [Test]
    public void AtTest()
    {
        var x1 = 1.5f;
        var y1 = 0.5f;
        var x2 = 1.5f;
        var y2 = -0.5f;

        GameObject apple = GameObject.Find("Apple");
        var controller = apple.GetComponent<AppleController>();

        // equal
        controller.transform.position = new Vector3(x1, y1);
        Assert.AreEqual(controller.At(new Vector3(x1, y1)), true);

        // not equal
        controller.transform.position = new Vector3(x1, y1);
        Assert.AreEqual(controller.At(new Vector3(x2, y2)), false);
    }
}
