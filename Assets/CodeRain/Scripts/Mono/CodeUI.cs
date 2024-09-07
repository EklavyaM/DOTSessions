using TMPro;
using UnityEngine;

namespace DOTSessions.CodeRain.Mono
{
    public class CodeUI : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TextMeshProUGUI text;

        public string Text { set => text.text = value; }
        public float Alpha { set => text.alpha = value; get => text.alpha; }
    }
}
