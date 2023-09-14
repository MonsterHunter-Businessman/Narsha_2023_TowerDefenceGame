using System.Security.Permissions;
using UnityEngine;

public class TestTwo : MonoBehaviour
{
    private TestOne testOne;

    private void Start()
    {
        testOne = GameObject.Find("Test").GetComponent<TestOne>();

        int valueFromA = testOne.MyVariable;

        Debug.Log(valueFromA);
    }
}
