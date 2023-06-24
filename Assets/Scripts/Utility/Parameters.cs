using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    [Serializable]
    public struct StuctParameters { public int i; public int j; }

    [Header("For created red cells")]
    public StuctParameters RedParameter1;
    public StuctParameters RedParameter2;
    public StuctParameters RedParameter3;
    public StuctParameters RedParameter4;
    public StuctParameters RedParameter5;

    [Header("For created green cells")]
    public StuctParameters GreenParameter1;
    public StuctParameters GreenParameter2;
    public StuctParameters GreenParameter3;
    public StuctParameters GreenParameter4;
    public StuctParameters GreenParameter5;

    [Header("For created yellow cells")]
    public StuctParameters YellowParameter1;
    public StuctParameters YellowParameter2;
    public StuctParameters YellowParameter3;
    public StuctParameters YellowParameter4;
    public StuctParameters YellowParameter5;

    [Header("For created block cells")]
    public StuctParameters BlockParameter1;
    public StuctParameters BlockParameter2;
    public StuctParameters BlockParameter3;
    public StuctParameters BlockParameter4;
    public StuctParameters BlockParameter5;
    public StuctParameters BlockParameter6;
}
