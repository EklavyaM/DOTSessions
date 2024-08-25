using TMPro;
using UnityEngine;

namespace DOTSessions.CodeRain
{
    public class Code : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TextMeshProUGUI text;

        private void Awake()
        {
            text.text = CodeSheet.GetRandomCharacter();
            text.alpha = Random.Range(0.1f, 1f);
        }
    }
}
