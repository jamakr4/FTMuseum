using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Textscript : MonoBehaviour
{ 
    public TMP_Text textMeshPro;
public float speed = 5f;
public float coloroffset = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TMP_Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textMeshPro != null)
        {
            textMeshPro.ForceMeshUpdate();
            var textInfo = textMeshPro.textInfo;
            int characterCount = textInfo.characterCount;

            for (int i=0; i<characterCount; i++)
            {
                if (textInfo.characterInfo[i].isVisible)
                {
                    float hue = Mathf.Repeat(Time.time * speed + i * coloroffset, 1f);
                    Color color = Color.HSVToRGB(hue, 1f, 1f);
                    int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                    textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].colors32[vertexIndex + 0] = color;
                    textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].colors32[vertexIndex + 1] = color;
                    textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].colors32[vertexIndex + 2] = color;
                    textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].colors32[vertexIndex + 3] = color;
                }
            }
            for (int i=0; i< characterCount; i++)
            {
                textInfo.meshInfo[i].mesh.colors32 = textInfo.meshInfo[i].colors32;
                textMeshPro.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
            }
        }
    }
}
