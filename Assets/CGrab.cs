using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGrab : MonoBehaviour
{
    public void AfterGrabbed()
    {
        Debug.Log("AfterGrabbed");
    }

    public void BeforeRelease()
    {
        Debug.Log("BeforeRelease");
    }

    public void OnDrop()
    {
        Debug.Log("OnDrop");
    }
}