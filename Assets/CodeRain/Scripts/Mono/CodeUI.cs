using TMPro;
using UnityEngine;

namespace DOTSessions.CodeRain.Mono
{
    public class CodeUI : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private CanvasGroup canvasGroup;

        public string Text { set => text.text = value; }
        public float Alpha
        {
            set => canvasGroup.alpha = value;
            get => canvasGroup.alpha;
        }
    }
}
