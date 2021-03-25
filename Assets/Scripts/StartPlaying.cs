using System;
using System.IO;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlaying : MonoBehaviour
{
    private string[][] matrix;

    public string GetRoom(int x, int y)
    {
        return matrix[x][y];
    }

    private string SortString(string input)
    {
        char[] characters = input.ToCharArray();
        Array.Sort(characters);
        return new string(characters);
    }

    public void Play()
    {
        Process generation = new Process();
        generation.StartInfo.FileName = "D:\\course\\Generation\\Debug\\Generation.exe";
        generation.Start();
        generation.WaitForExit();

        string[] inputMatrix = File.ReadAllLines("D:\\course\\Fairy scull 1.0\\Fairy scull 1.0\\matrix.txt");
        int x, y;
        x = inputMatrix[inputMatrix.Length - 1][0] - '0';
        x--;
        y = Convert.ToInt32(inputMatrix[inputMatrix.Length - 1][2]) - '0';
        y--;
        Array.Resize<string>(ref inputMatrix, inputMatrix.Length - 1);

        for (int i = 0; i < inputMatrix.Length; i++)
        {
            for (int j = 0; j < inputMatrix[i].Length - 1; j++) {
                if (inputMatrix[i][0] == ' ')
                {
                    inputMatrix[i] = "E" + inputMatrix[i];
                }
                if (inputMatrix[i][j] == ' ' && inputMatrix[i][j + 1] == ' ')
                {
                    inputMatrix[i] = inputMatrix[i].Insert(j + 1, "E");
                }
            }
            if (i == 3)
            {
                inputMatrix[i] = "L" + inputMatrix[i];
            }
        }

        matrix = new string[7][];

        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new string[7];
        }

        for (int i = 0; i < inputMatrix.Length; i++)
        {
            matrix[i] = inputMatrix[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                matrix[i][j] = SortString(matrix[i][j]);
            }
        }
        
        matrix[x][y] = "Final";
        
        if (matrix[3][0] == "E" || matrix[3][0] == "LE")
        {
            matrix[3][0] = "Final";
        }

        Level.Initialize(matrix);
        Level.CurrentPosition = new Pair(3, -1);
        SceneManager.LoadScene("Enter");
    }
}
