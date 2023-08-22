using UnityEngine;
using UnityEngine.UIElements;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform _pointPrefab;
    [SerializeField, Range(10, 100)] private int _resolution = 10;

    private Transform[] _points;

    private void Awake()
    {
        CreateGraph();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DestroyGraph();
            CreateGraph();
        }

        UpdateGraph();
    }

    private void CreateGraph()
    {
        float step = 2f / _resolution;
        Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;
        _points = new Transform[_resolution];
        for (int i = 0; i < _resolution; i++)
        {
            Transform point = _points[i] = Instantiate(_pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    private void UpdateGraph()
    {
        float time = Time.time;
        for (int i = 0; i < _points.Length; i++)
        {
            Transform point = _points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            point.localPosition = position;
        }
    }

    private void DestroyGraph()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
