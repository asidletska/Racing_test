using System;
using UnityEngine;

public class CarShowPreview : MonoBehaviour
{
    [SerializeField] private Transform previewRoot;
    [SerializeField] private float rotationSpeed = 30f;

    [Header("Keep enabled (optional)")]
    [SerializeField] private MonoBehaviour[] keepEnabled;

    private GameObject _current;

    private void Update()
    {
        if (_current != null)
            _current.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    public void Show(GameObject racePrefab)
    {
        if (previewRoot == null) return;

        Clear();
        if (racePrefab == null) return;

        _current = Instantiate(racePrefab, previewRoot);
        _current.transform.localPosition = Vector3.zero;
        _current.transform.localRotation = Quaternion.identity;
        _current.transform.localScale = Vector3.one;

        MakePreviewSafe(_current);
    }

    private void Clear()
    {
        if (_current != null) Destroy(_current);
        _current = null;
    }

    private void MakePreviewSafe(GameObject go)
    {
        foreach (var rb in go.GetComponentsInChildren<Rigidbody>(true))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        foreach (var col in go.GetComponentsInChildren<Collider>(true))
            col.enabled = false;

        foreach (var a in go.GetComponentsInChildren<AudioSource>(true))
            a.enabled = false;

        var allow = keepEnabled ?? Array.Empty<MonoBehaviour>();
        foreach (var mb in go.GetComponentsInChildren<MonoBehaviour>(true))
        {
            if (mb == null) continue;

            bool allowed = false;
            for (int i = 0; i < allow.Length; i++)
            {
                if (allow[i] == mb) { allowed = true; break; }
            }

            if (!allowed)
                mb.enabled = false;
        }
    }
}
