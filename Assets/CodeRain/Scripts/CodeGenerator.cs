using UnityEngine;
using UnityEngine.UI;

namespace DOTSessions.CodeRain
{
    public class CodeGenerator : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject prefab;

        [Header("Properties")]
        [SerializeField] private GridLayoutGroup gridLayout;

        private void Start()
        {
            Generate();
        }

        private void Generate()
        {
            RectTransform gridRect = gridLayout.transform as RectTransform;

            int horizontal = Mathf.FloorToInt(gridRect.rect.width / gridLayout.cellSize.x);
            int vertical = Mathf.FloorToInt(gridRect.rect.height / gridLayout.cellSize.y);
            int cellCount = horizontal * vertical;

            for (int i = 0; i < cellCount; ++i)
            {
                _ = Instantiate(prefab, gridRect);
            }
        }
    }
}
