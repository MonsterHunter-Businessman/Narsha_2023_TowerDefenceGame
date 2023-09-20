using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [HideInInspector]
    public Vector3[][] oneStage = new Vector3[][] {
            new Vector3 [] { new Vector3 (9, 2, 0), new Vector3 (3, 2, 0), new Vector3 (3, 1, 0), new Vector3 (1, 1, 0), new Vector3 (1, 0, 0), new Vector3 (-2, 0, 0)},
            new Vector3 [] { new Vector3 (9, 0, 0), new Vector3 (3, 0, 0), new Vector3 (3, 1, 0), new Vector3 (1, 1, 0), new Vector3 (1, 0, 0), new Vector3 (-2, 0, 0)},
            new Vector3 [] { new Vector3 (9, -2, 0), new Vector3 (3, -2, 0), new Vector3 (3, -1, 0), new Vector3 (1, -1, 0), new Vector3 (1, 0, 0), new Vector3 (-2, 0, 0)}
    };

    [HideInInspector]
    public Vector3[][] twoStage = new Vector3[][] {

    };

    [HideInInspector]
    public Vector3[][] threeStage = new Vector3[][] {

    };
}
    