using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemMerge : ButtonBase
{

    [SerializeField] private StickmanPlacer stickmanPlacer;

    private bool Merge()
    {

        Dictionary<int, List<StickmanController>> stickmansOnGame = EventManager.E_StickmansManager.Invoke().stickmansOnGame;

        for (int level = 0; level < 5; level++)
        {

            if (stickmansOnGame[level].Count >= 3 && EventManager.E_StickmansManager.Invoke().stickmansOnGame[level + 1].Count != stickmanPlacer.maxStickmanCount)
            {

                int index = stickmansOnGame[level].Count - 1;

                for (int stickmanIndex = index; stickmanIndex >= index - 2; stickmanIndex--)
                {

                    List<StickmanController> controllers = stickmansOnGame[level];

                    controllers[stickmanIndex].gameObject.SetActive(false);
                    EventManager.E_ObjectPool.Invoke().pools[level].pooledObjects.Add(controllers[stickmanIndex]);
                    controllers.Remove(controllers[stickmanIndex]);

                    print(stickmanIndex);

                }

                EventManager.E_StickmansManager.Invoke().stickmansOnGame = stickmansOnGame;

                StickmanController newobj = EventManager.E_ObjectPool?.Invoke().GetPooledObject(level + 1);

                stickmanPlacer.SetTransform(newobj.obj_Main, newobj.level);

                return true;

            }

        }

        return false;

    }

    public bool CharNumControl(Dictionary<int, List<StickmanController>> stickmans)
    {

        for (int i = 0; i < 3; i++)
        {
            if (stickmans[i].Count >= 3)
            {

                main_Button.SetActive(true);

                return true;
            }
        }

        return false;

    }

    public override void OnClickButton()
    {
        if (/*CheckAmount() && */Merge())
        {
            UpdateCost();
            UpdateText();
        }
    }

}
