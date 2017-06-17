using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSaver : MonoBehaviour {

    public static List<Vector3> PathForLevel_1()
    {
        var aPath = new List<Vector3>();
        aPath.Add(new Vector3(-3.68f, 0.179f));
        aPath.Add(new Vector3(2f, 3.05f));
        aPath.Add(new Vector3(5.9f, 1.19f));
        aPath.Add(new Vector3(0.26f, -2.14f));
        aPath.Add(new Vector3(4.92f, -4.07f));
        return aPath;
    }
    
    public static List<Vector3> PathForLevel_2()
    {
        var aPath = new List<Vector3>();
        aPath.Add(new Vector3(-3.68f, 0.179f));
        aPath.Add(new Vector3(2f, 3.05f));
        aPath.Add(new Vector3(5.9f, 1.19f));
        aPath.Add(new Vector3(0.80f, -1.73f));
        aPath.Add(new Vector3(4.25f, -3.49f));
        aPath.Add(new Vector3(12.59f,1.16f));
        return aPath;
    }
    
    public static List<Vector3> PathForLevel_3()
    {
        var aPath = new List<Vector3>();
        aPath.Add(new Vector3(-2.56f, 2.33f));
        aPath.Add(new Vector3(1.72f, 4.27f));
        aPath.Add(new Vector3(4.90f, 2.66f));
        aPath.Add(new Vector3(-3.83f, -1.54f));
        aPath.Add(new Vector3(-0.48f, -3.62f));
        aPath.Add(new Vector3(7.68f,0.45f));
        aPath.Add(new Vector3(11.47f, -1.94f));
        return aPath;
    }
    
}
