using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    public GameObject cubeprefab;
    public int cubeCount = 1000;
    public float spacing = 2f;
    
    private void Start()
    {
        int gridSize = Mathf.CeilToInt(Mathf.Pow(cubeCount, 1f / 3f));
        int count = 0;

        for (int x = 0; 0 < gridSize && count < cubeCount; x++)
        {
            for (int y = 0; 0 < gridSize && count < cubeCount; y++)
            {
                for (int z = 0; 0 < gridSize && count < cubeCount; z++)
                {
                    Vector3 position = new Vector3(x, y, z) * spacing;
                    Instantiate(cubeprefab, position, Quaternion.identity);
                    count++;
                }
            }
        }
    }
}
