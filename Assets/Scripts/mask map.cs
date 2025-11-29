using UnityEngine;
using UnityEditor;

public class HDRPMaskMapCreator : EditorWindow
{
    Texture2D metallicMap;
    Texture2D aoMap;
    Texture2D roughnessMap;
    Texture2D detailMaskMap;
    string savePath = "Assets/MaskMap.png";

    [MenuItem("Tools/HDRP/Mask Map Creator")]
    static void OpenWindow()
    {
        GetWindow(typeof(HDRPMaskMapCreator), false, "HDRP Mask Map Creator");
    }

    void OnGUI()
    {
        GUILayout.Label("HDRP Mask Map Generator", EditorStyles.boldLabel);

        metallicMap = (Texture2D)EditorGUILayout.ObjectField("Metallic Map (R)", metallicMap, typeof(Texture2D), false);
        aoMap = (Texture2D)EditorGUILayout.ObjectField("AO Map (G)", aoMap, typeof(Texture2D), false);
        detailMaskMap = (Texture2D)EditorGUILayout.ObjectField("Detail Mask (B)", detailMaskMap, typeof(Texture2D), false);
        roughnessMap = (Texture2D)EditorGUILayout.ObjectField("Roughness Map (A - Inverted)", roughnessMap, typeof(Texture2D), false);

        savePath = EditorGUILayout.TextField("Save Path", savePath);

        if (GUILayout.Button("Create Mask Map"))
        {
            CreateMaskMap();
        }
    }

    void CreateMaskMap()
    {
        if (metallicMap == null || aoMap == null || roughnessMap == null)
        {
            EditorUtility.DisplayDialog("Error", "Metallic, AO ve Roughness map zorunludur.", "OK");
            return;
        }

        int width = metallicMap.width;
        int height = metallicMap.height;

        Texture2D maskMap = new Texture2D(width, height, TextureFormat.RGBA32, false);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float r = metallicMap.GetPixel(x, y).r;
                float g = aoMap != null ? aoMap.GetPixel(x, y).r : 1f;
                float b = detailMaskMap != null ? detailMaskMap.GetPixel(x, y).r : 1f;

                // Roughness = 1 - smoothness
                float rough = roughnessMap.GetPixel(x, y).r;
                float a = 1f - rough; // invert

                maskMap.SetPixel(x, y, new Color(r, g, b, a));
            }
        }

        maskMap.Apply();

        byte[] bytes = maskMap.EncodeToPNG();
        System.IO.File.WriteAllBytes(savePath, bytes);
        AssetDatabase.Refresh();

        EditorUtility.DisplayDialog("Success", "Mask Map oluşturuldu!", "OK");
    }
}

