using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour {
    private List<Transform> _waypoints = new List<Transform>();
    private List<Vector3> buldedPath =  new List<Vector3>();

    private void Start()
    {       
        for(int i=0; i <this.transform.childCount; i++)
        {
            var currentTransform = transform.GetChild(i);
            this._waypoints.Add(currentTransform); 
            this.buldedPath.Add(currentTransform.position);
        }
    }

    public List<Vector3> GetPath()
    {
        return this.buldedPath;
    }
}
