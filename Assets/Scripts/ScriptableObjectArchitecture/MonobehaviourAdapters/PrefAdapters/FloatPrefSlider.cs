using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
public class FloatPrefSlider : MonoBehaviour
{
    [SerializeField] private FloatPref pref;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI numberDisplay;
    [SerializeField] private string formatString = "F1";

    private void Awake()
    {
        slider.onValueChanged.AddListener(UpdateValue);
        pref.Link(UpdateSlider);
        slider.minValue = pref.MinValue;
        slider.maxValue = pref.MaxValue;
    }

    private void UpdateSlider(float value)
    {
        slider.value = value;
        if (numberDisplay) numberDisplay.text = value.ToString(formatString);
    }

    private void UpdateValue(float value)
    {
        pref.Value = value;
        pref.SaveCurrentValue();
        if (numberDisplay) numberDisplay.text = value.ToString(formatString);
    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(UpdateValue); //not sure if this is needed
        pref.Unlink(UpdateSlider);
    }
}
}
