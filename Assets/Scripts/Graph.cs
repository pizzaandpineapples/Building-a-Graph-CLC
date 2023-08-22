using UnityEngine;
using UnityEngine.UIElements;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform _pointPrefab;
    [SerializeField, Range(10, 100)] private int _resolution = 10;

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
    }

    private void CreateGraph()
    {
        float step = 2f / _resolution;
        Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;
        for (int i = 0; i < _resolution; i++)
        {
            Transform point = Instantiate(_pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
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
