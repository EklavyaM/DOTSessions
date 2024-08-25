using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DOTSessions.CodeRain
{
    public class CodeUIGenerator : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject prefab;

        [Header("Properties")]
        [SerializeField] private GridLayoutGroup gridLayout;

        [Header("Events")]
        public UnityEvent<CodeUI[]> OnCodeGenerated;

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

            CodeUI[] codes = new CodeUI[cellCount];

            for (int i = 0; i < cellCount; ++i)
            {
                codes[i] = Instantiate(prefab, gridRect).GetComponent<CodeUI>();
            }

            OnCodeGenerated?.Invoke(codes);
        }
    }
}
