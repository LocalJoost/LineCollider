using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class ColorToggler : MonoBehaviour, IInputClickHandler {

    [SerializeField]
    private Color _toggleColor = Color.red;

    private Color _originalColor;

    private Material _material;
	void Start ()
	{
	    _material = GetComponent<Renderer>().material;
        _originalColor = _material.color;
	}
	
    public void OnInputClicked(InputClickedEventData eventData)
    {
        _material.color = _material.color == _originalColor ? _toggleColor : _originalColor;
    }
}
