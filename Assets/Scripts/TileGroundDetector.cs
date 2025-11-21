using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundDetector : MonoBehaviour
{
    public Tilemap grassTilemap;
    public Tilemap gravelTilemap;

    private AudioPlayByMaterial apbm;

    private void Start()
    {
        apbm =  GameObject.Find("PlayerVisual").GetComponent<AudioPlayByMaterial>();
    }

    void Update()
    {
        Vector3 worldPos = transform.position;
        Vector3Int cellPos = grassTilemap.WorldToCell(worldPos);

        bool onGravel = gravelTilemap.GetTile(cellPos) != null;
        bool onGrass = grassTilemap.GetTile(cellPos) != null;

        if (onGravel && apbm.currentMaterial != AudioPlayByMaterial.CurrentMaterial.Gravel)
        {
            apbm.SetMaterial(1);
        }
        else if (onGrass && !onGravel && apbm.currentMaterial != AudioPlayByMaterial.CurrentMaterial.Grass)
        {
            apbm.SetMaterial(0);
        }
    }
}
