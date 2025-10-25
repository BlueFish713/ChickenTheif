using AYellowpaper.SerializedCollections;
using UnityEngine;

[Singleton, RequireInScene]
public class FishImageRepository : MonoBehaviour
{
    [SerializedDictionary("Fish", "Image(Sprite)")]
    public SerializedDictionary<FishType, Sprite> fishImages = new SerializedDictionary<FishType, Sprite>();
}
