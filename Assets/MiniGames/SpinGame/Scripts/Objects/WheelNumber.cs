using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpinGame.Gameplay.Object
{
    public class WheelNumber : MonoBehaviour
    {
        [SerializeField] private Image backgroundImageGreen;
        [SerializeField] private Image backgroundImageBlue;
        [SerializeField] private Image backgroundImageWhite;
        [SerializeField] private TextMeshProUGUI numberText;

        public void Initialize(Type type, int number)
        {
            backgroundImageGreen.gameObject.SetActive(type == Type.Green);
            backgroundImageBlue.gameObject.SetActive(type == Type.Blue);
            backgroundImageWhite.gameObject.SetActive(type == Type.White);
            numberText.text = number.ToString();
        }
        
        public enum Type
        {
            Green,
            Blue,
            White
        }
    }
}