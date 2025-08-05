using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "ImageDatabase", menuName = "Database/ImageDatabase")]
public class ImageDatabase : ScriptableObject
{
    [SerializeField] private List<FoodImage> entries;

    private Dictionary<string, Sprite> _dictionary;

    private void OnEnable()
    {
        _dictionary = new Dictionary<string, Sprite>();
        foreach (var entry in entries)
        {
            if (!_dictionary.ContainsKey(entry.Name))
            {
                _dictionary.Add(entry.Name, entry.Image);
            }
        }
    }

    public Sprite GetImage(string name)
    {
        if (_dictionary != null && _dictionary.TryGetValue(name, out var sprite))
        {
            return sprite;
        }
        Debug.LogWarning($"‰æ‘œ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ: {name}");
        return null;
    }
}
