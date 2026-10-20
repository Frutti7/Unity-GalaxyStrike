using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private GameObject model;

    private void Start()
    {
        if (model == null)
        {
            Debug.LogError("Model is not assigned!");
            return;
        }

        Renderer[] renderers =
            model.GetComponentsInChildren<Renderer>(true);

        foreach (Renderer r in renderers)
        {
            Debug.Log(
                "Renderer: " + r.name +
                " | Bounds center: " + r.bounds.center +
                " | Transform position: " + r.transform.position +
                " | Bounds size: " + r.bounds.size
            );
        }
    }
}