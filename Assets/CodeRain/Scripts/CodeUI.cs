using TMPro;
using UnityEngine;

namespace DOTSessions.CodeRain
{
    public class CodeUI : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TextMeshProUGUI text;

        public string Text { set => text.text = value; }
        public float Alpha { set => text.alpha = value; }
    }
}
