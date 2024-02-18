using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerManager : MonoBehaviour
{
    [System.Serializable]
    public class Marker
    {
        public Vector3 position;
        public Quaternion rotation;
        public Marker(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }
    }

    public List<Marker> markers = new List<Marker>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateMarkers();
    }

    public void UpdateMarkers() => markers.Add(new Marker(transform.position, transform.rotation));
    public void ClearMarkers()
    {
        markers.Clear();
        markers.Add(new Marker(transform.position, transform.rotation));
    }
}
