using UnityEngine;
using ZigSimTools;
using Quaternion = UnityEngine.Quaternion;

public class StageRotator : MonoBehaviour
{
    Quaternion targetRotation;
    float yValue;
    float speed = 8f;

    void Start ()
    {
        ZigSimDataManager.Instance.StartReceiving ();
        ZigSimDataManager.Instance.QuaternionCallBack += (ZigSimTools.Quaternion q) =>
        {
            //var newQut = new Quaternion ((float) - q.x, (float) - q.z, (float) - q.y, (float) q.w);
            yValue = Map((float) q.y, -90f, 90f, 0f, 1f);
            var newQut = new Quaternion (Mathf.Clamp ((float) q.y, -0.05f, 0.05f), 0f, 0f, (float) q.w);
            //var newRot = newQut * Quaternion.Euler (90f, 0, 0);
            targetRotation = newQut;
        };
    }

    void Update ()
    {
        //if (-10.0f < transform.rotation.y && transform.rotation.x < 10.0f)
        //transform.localRotation = targetRotation;
        transform.localRotation = Quaternion.Lerp (
            transform.localRotation,
            targetRotation,
            Time.deltaTime * speed * yValue);
    }

    float Map (float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }
}