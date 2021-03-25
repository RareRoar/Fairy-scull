
using System.Diagnostics;
using UnityEngine;

public class Path : MonoBehaviour
{
    private void Start()
    {
        Process generation = new Process();
        generation.StartInfo.FileName = "D:\\course\\Generation\\Debug\\Generation.exe";
        generation.Start();
        generation.WaitForExit();
    }
}

