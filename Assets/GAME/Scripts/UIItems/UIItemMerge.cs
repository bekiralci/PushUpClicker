using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemMerge : ButtonBase
{
    
    private bool Merge()
    {

        Dictionary<int, List<StickmanController>> stickmansOnGame = EventManager.E_StickmansManager.Invoke().stickmansOnGame;

        for (int level = 0; level < 3; level++)
        {

            if (stickmansOnGame[level].Count >= 3)
            {

                for (int j = 3 - 1; j >= 0; j--)
                {

                    stickmansOnGame[level][j].gameObject.SetActive(false);
                    stickmansOnGame[level].Remove(stickmansOnGame[level][j]);

                }

                EventManager.E_StickmansManager.Invoke().stickmansOnGame = stickmansOnGame;
                EventManager.E_ObjectPool?.Invoke().GetPooledObject(level + 1);

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
        if (CheckAmount() && Merge())
        {
            UpdateCost();
            UpdateText();
        }
    }

}
