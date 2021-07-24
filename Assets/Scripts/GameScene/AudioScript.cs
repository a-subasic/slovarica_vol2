using TMPro;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "B";
    }
}
