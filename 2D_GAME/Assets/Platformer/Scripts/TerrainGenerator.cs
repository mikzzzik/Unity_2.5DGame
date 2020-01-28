using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using CustomTileMap;

public class TerrainGenerator : MonoBehaviour
{

    public int Height, Width;
    public GroundTile Tile;
    
    void Start()
    {
        var tileMap = Generator();
        GetComponent<TileMapRender>().Render(tileMap);
    }

  
    public ITilemap Generator()
    {
        
        int groundHeight = 25;
        HeightmapBasedTilemap tilemap = new HeightmapBasedTilemap(Width, Tile);
        for (int x = 0; x < Width; x++)
        {
            if (x % 2 == 0)
            {
                groundHeight += Random.Range(-1, 2);
            }
            tilemap.SetHeight(x, groundHeight);
           
        }
        return tilemap;
    }
   
}
namespace CustomTileMap
{
    public interface ICell
    {
        void Refresh(Vector2Int position, ITilemap tilemap, GameObject gameObject);
    }
    public interface ITilemap
    {
        int Count { get; }
        int Height { get; }
        int Width { get; }
        ICell GetCell(Vector2Int position);
    }

    [CreateAssetMenu(menuName ="GroundTile")]
    public class GroundTile : ScriptableObject,ICell
    {
        public void Refresh(Vector2Int position, ITilemap tilemap, GameObject gameObject)
        {
            throw new System.NotImplementedException();
        }
    }
    public class HeightmapBasedTilemap : ITilemap
    {

        public int Count => _heights.Sum();
        public int Height => _heights.Max();      
        public int Width => _heights.Length;

        private int[] _heights;
        private ICell _cell;
       
        public HeightmapBasedTilemap(int width, ICell cell)
        {
            _heights = new int[width];
            _cell = cell;
        }
        public  void SetHeight(int x, int value )
        {
            if (x < 0 && x >= _heights.Length) throw new System.ArgumentOutOfRangeException("x");

            _heights[x] = value; 

        }
        public ICell GetCell(Vector2Int position)
        {
            if (position.x < 0 && position.x >= _heights.Length) throw new System.ArgumentOutOfRangeException("x");
       
            if (position.y > _heights[position.x])
            {
                return null;
            }
            else
            {
                return _cell;
            }
        }
       
    }
}