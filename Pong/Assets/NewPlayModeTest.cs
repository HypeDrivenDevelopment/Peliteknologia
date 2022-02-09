using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewPlayModeTest {

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator NewPlayModeTestWithEnumeratorPasses() {

        // luodaan peliobjekti
        var pallo = new GameObject();

        // annetaan sille rigidbody-ominaisuudet ja otetaan y-positio
        pallo.AddComponent<Rigidbody>();
        var originalPosition = pallo.transform.position.y;

        // lisätään ominaisuudet
        pallo.AddComponent<PalloToiminnot>();

        yield return new WaitForFixedUpdate();

        // testataan position muuttuminen
        Assert.AreNotEqual(originalPosition, pallo.transform.position.y);
    }
}
