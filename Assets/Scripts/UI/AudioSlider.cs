using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer = null;
    [SerializeField] private Slider audioSlider = null;
    [SerializeField] private FloatVariable volumeVariable = null;

    private void Start() {
        audioSlider.value = volumeVariable.Value;
        audioMixer.SetFloat("volume", volumeVariable.Value);
    }

    public void Change() {
        volumeVariable.Set(audioSlider.value);
        audioMixer.SetFloat("volume", volumeVariable.Value);
    }
}
