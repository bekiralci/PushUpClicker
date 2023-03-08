using PathCreation;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanPlacer : MonoBehaviour
{

    public int maxStickmanCount;
    public List<PathCreator> paths;

    public void SetTransform(Transform stickmanBase, int level)
    {

        float pathLength = paths[level].path.length;
        float point = pathLength / (maxStickmanCount + 1);

        float iter;

        iter = (EventManager.E_StickmansManager.Invoke().stickmansOnGame[level - 1].Count) * point;

        stickmanBase.position = paths[level - 1].path.GetPointAtDistance(iter);

    }

}
