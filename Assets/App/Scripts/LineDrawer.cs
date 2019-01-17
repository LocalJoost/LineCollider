using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField]
    private GameObject _container;

    [SerializeField]
    private GameObject _lineObject;

    [SerializeField]
    private List<FromToHolder> _lineFromTo;

	void Start ()
	{
	    var direction = 1;
	    foreach (var line in _lineFromTo)
	    {
	        var lineGameObject = Instantiate(_lineObject);
	        var controller = lineGameObject.GetComponent<LineController>();
	        var inBetweenPoint = (line.To.transform.position - line.From.transform.position) * 0.5f +
	                             Vector3.forward * 0.1f * direction;
	        lineGameObject.transform.parent = _container.transform;

            controller.SetPoints(new []{line.From.transform.position, line.From.transform.position + inBetweenPoint, line.To.transform.position });
	        direction = -direction;
	    }
	}
}
