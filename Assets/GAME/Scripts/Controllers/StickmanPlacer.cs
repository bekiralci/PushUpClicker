using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanPlacer : MonoBehaviour
{

    public int maxStickmanCount;
    public List<PathCreator> paths;

    [ContextMenu("TEST")]
    public void SetTransform(Transform stickmanBase, int level)
    {

        float pathLength = paths[level].path.length;
        float point = pathLength / (maxStickmanCount + 1);

        float iter;

        iter = (EventManager.E_StickmansManager.Invoke().currentCars[level - 1].Count + 1) * point;

        stickmanBase.position = paths[level].path.GetPointAtDistance(iter);

    }

}
