using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestMono : MonoBehaviour
{
    public int inputval;
    public NotifyValue<int> myValue = new NotifyValue<int>();

    public UnityEvent MyEvent;
    public void TestMethod()
    {
        MyEvent?.Invoke();

    }
    public void TestAAA()
    {
        Debug.Log("ASDASDS");
    }
    private void Subscribe()
    {
        myValue.OnvalueChanged += HandleValueChanged;
    }
    private void UnSubscribe()
    {
        myValue.OnvalueChanged -= HandleValueChanged;
    }

    private void HandleValueChanged(int prev, int next)
    {
        Debug.Log($"MyValue 값이 {prev}에서 {next}로 변환");
    }

    private int Add4(int a)
    {
        Debug.Log("add4");
        return a + 4;
    }
    private int Add5(int b)
    {
        Debug.Log("add5");
        return b + 4;
    }
    [ContextMenu("ResetMono")]
    public void ResetMono()
    {
        Debug.Log("This calss will be cleared");
        
    }
}
