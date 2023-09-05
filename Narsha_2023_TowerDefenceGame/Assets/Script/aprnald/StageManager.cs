using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public class OnStage {
        public Vector3[][] oneStage = new Vector3[][] { 
            new Vector3 [] { new Vector3 (9, 2, 0), new Vector3 (3, 2, 0), new Vector3 (3, 1, 0), new Vector3 (1, 1, 0), new Vector3 (1, 0, 0), new Vector3 (-2, 0, 0)}, 
            new Vector3 [] { new Vector3 (0, 0, 0), new Vector3 (3, 0, 0), new Vector3 (3, 1, 0), new Vector3 (1, 1, 0), new Vector3 (1, 0, 0), new Vector3 (-2, 0, 0)},
            new Vector3 [] { new Vector3 (9, -2, 0), new Vector3 (3, -2, 0), new Vector3 (3, -1, 0), new Vector3 (1, -1, 0), new Vector3 (1, 0, 0), new Vector3 (-2, 0, 0)}
        };
    }

    public class TwoStage
    {

    }



}
