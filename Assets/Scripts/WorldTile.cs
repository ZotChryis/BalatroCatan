using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class WorldTile : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TextMeshPro m_label;

    private GameObject m_tile;

    public void Awake()
    {
        // Testing, set your value to a random 1-12
        SetRollValue(Random.Range(1, 13));
    }
    
    public void SetRollValue(int value)
    {
        m_label.SetText(value.ToString());
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        var selectedTile = Game.Instance.Hand.Selected;
        if (selectedTile == null)
        {
            return;
        }

        if (m_tile != null)
        {
            return;
        }

        m_tile = Instantiate(selectedTile.WorldPrefab, transform);
    }
}
