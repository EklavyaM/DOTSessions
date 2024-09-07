using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DOTSessions.CodeRain.Mono
{
    public class CodeUIGenerator : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject prefab;

        [Header("Properties")]
        [SerializeField] private GridLayoutGroup gridLayout;

        [Header("Events")]
        public UnityEvent<CodeUI[], Vector2Int> OnCodeGenerated;

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
                codes[i].Alpha = 0f;
            }

            _ = StartCoroutine(DestroyGrid());

            OnCodeGenerated?.Invoke(codes, new Vector2Int(horizontal, vertical));
        }

        private IEnumerator DestroyGrid()
        {
            yield return null;

            Destroy(gridLayout);
        }
    }
}
