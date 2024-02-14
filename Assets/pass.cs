//Unity C#
using System;
using UnityEngine.Networking;
using UnityEngine.Profiling;
using System.Collections;

[Serializable]
public class Records
{
    public Record[] records;
}

[Serializable]
public class Record
{
    public string address;
    public string name;
    public int score;
    public string created;
    public string updated;
}