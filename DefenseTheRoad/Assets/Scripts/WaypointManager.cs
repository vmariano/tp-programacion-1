using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {
    private List<Vector3> buldedPath =  new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            var currentTransform = transform.GetChild(i);
            this.buldedPath.Add(currentTransform.position);
        }
    }

    public List<Vector3> GetPath()
    {
        return this.buldedPath;
    }
}
