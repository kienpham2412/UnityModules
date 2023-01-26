using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KPModules.Responsive
{
    public class GridLayoutAutoScale : CanvasAutoScale
    {
        public GridLayoutGroup gridLayoutGroup;

        private void Reset()
        {
            gridLayoutGroup = GetComponent<GridLayoutGroup>();
        }

        public override void RescaleElements()
        {
#if UNITY_EDITOR
            if ((float)canvasRect.rect.width / (float)canvasRect.rect.height >= 0.6f) // ipad, tablet screen
            {
                float width = canvasRect.rect.width;
                float totalSpacingX = width - gridLayoutGroup.padding.left - gridLayoutGroup.padding.right - gridLayoutGroup.cellSize.x * 7;
                Vector2 spacing = gridLayoutGroup.spacing;
                spacing.x = totalSpacingX / 6;
                gridLayoutGroup.spacing = spacing;
            }
            else gridLayoutGroup.spacing = Vector2.one * 25;
#else
        if ((float)Screen.width / (float)Screen.height >= 0.6f)
        {
            float width = canvasRect.rect.width;
            float totalSpacingX = width - gridLayoutGroup.padding.left - gridLayoutGroup.padding.right - gridLayoutGroup.cellSize.x * 7;
            Vector2 spacing = gridLayoutGroup.spacing;
            spacing.x = totalSpacingX / 6;
            gridLayoutGroup.spacing = spacing;
        }
        else gridLayoutGroup.spacing = Vector2.one * 25;
#endif
        }
    }
}
