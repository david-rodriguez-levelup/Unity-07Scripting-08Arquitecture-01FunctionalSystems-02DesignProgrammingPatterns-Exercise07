using UnityEngine;
using UnityEngine.Assertions;

public class SingleLaunchAction : AbstractLaunchAction
{

    public override void Launch()
    {
        //Assert.IsTrue(Time.inFixedTimeStep);

        Rigidbody rb = base.TryGetInstance(Quaternion.identity);

        if (rb != null)
        {
            rb.AddForce(rb.transform.up * base.launchForce);
        } 

    }

}
