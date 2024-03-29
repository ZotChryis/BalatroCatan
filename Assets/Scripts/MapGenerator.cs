using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public MapGeneratorSettings Settings;

    private int m_totalTileProbability;
    private GameObject[] m_tileProbability;
    
    public void Initialize()
    {
        GenerateProbabilityTable();
    }

    public void GenerateProbabilityTable()
    {
        // O(2N) because we have to find the total first to properly initialize the array.
        m_totalTileProbability = 0;
        foreach (var settingsTileProbability in Settings.TileProbabilities)
        {
            m_totalTileProbability += settingsTileProbability.Amount;
        }

        m_tileProbability = new GameObject[m_totalTileProbability];
        int tilesPlaced = 0;
        foreach (var settingsTileProbability in Settings.TileProbabilities)
        {
            for (int i = 0; i < settingsTileProbability.Amount; i++)
            {
                m_tileProbability[tilesPlaced] = settingsTileProbability.Prefab;
                tilesPlaced++;
            }
        }
    }
    
    public void GenerateMap()
    {
        // Kill all children objects (for when regenerating)
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        float zOffsetEven = Mathf.Sqrt(3) * Settings.HexSize;
        for (int row = 0; row < Settings.Width; row++)
        {
            for (int col = 0; col < Settings.Height; col++)
            {
                // We check null because it's valid that a tile rolls empty (for now?)
                GameObject tile = GetRandomTile();
                if (tile == null)
                {
                    continue;
                }
                
                float zPos = col * (zOffsetEven + Settings.Gap);
                if (row % 2 == 1)
                {
                    zPos += (zOffsetEven) / 2f;
                }

                float xPos = row * 1.5f * (Settings.HexSize + Settings.Gap);
                
                Vector3 position = new Vector3(xPos, 0, zPos);

                Instantiate(tile, position, Quaternion.identity, transform);
            }
        }
    }
    
    private GameObject GetRandomTile()
    {
        int randomIndex = Random.Range(0, m_totalTileProbability);
        return m_tileProbability[randomIndex];
    }

}
