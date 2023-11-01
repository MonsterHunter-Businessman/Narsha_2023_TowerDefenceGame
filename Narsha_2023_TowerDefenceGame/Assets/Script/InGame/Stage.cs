using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [HideInInspector]
    public List<List<List<Vector3>>> InGameStage = new List<List<List<Vector3>>> {
        new List<List<Vector3>> { 
            new List<Vector3> { new Vector3 (3, 2, 0), new Vector3 (3, 1, 0), new Vector3 (1, 1, 0), new Vector3 (1, 0, 0), new Vector3 (-2, 0, 0)},
            new List<Vector3> { new Vector3 (3, 0, 0), new Vector3 (3, 1, 0), new Vector3 (1, 1, 0), new Vector3 (1, 0, 0), new Vector3 (-2, 0, 0)},
            new List<Vector3> { new Vector3 (3, -2, 0), new Vector3 (3, -1, 0), new Vector3 (1, -1, 0), new Vector3 (1, 0, 0), new Vector3 (-2, 0, 0)}},
        new List<List<Vector3>> {
            new List<Vector3> { new Vector3 (8, 2, 0), new Vector3 (8, 0, 0), new Vector3 (5, 0, 0), new Vector3 (5, 2, 0), new Vector3 (3, 2, 0), new Vector3 (3, 1, 0), new Vector3 (0, 1, 0), new Vector3 (0, 0, 0), new Vector3 (-2, 0, 0)},
            new List<Vector3> { new Vector3 (5, 0, 0), new Vector3 (5, 2, 0), new Vector3 (3, 2, 0), new Vector3 (3, 1, 0), new Vector3 (0, 1, 0), new Vector3 (0, 0, 0), new Vector3 (-2, 0, 0)},
            new List<Vector3> { new Vector3 (5, -1, 0), new Vector3 (1, -1, 0), new Vector3 (1, 0, 0), new Vector3 (-2, 0, 0)}
        }
    };


}