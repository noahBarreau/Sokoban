Shader "Custom/CheckerboardShader"
{
    Properties
    {
        _Color1 ("Color 1", Color) = (1, 1, 1, 1) // Blanc
        _Color2 ("Color 2", Color) = (0, 0, 0, 1) // Noir
        _TileSize ("Tile Size", Float) = 1.0 // Taille des cases
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            // Propri�t�s du mat�riau
            float _TileSize;
            float4 _Color1;
            float4 _Color2;

            // Vertex Shader
            struct appdata_t
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.xy; // Utilisation des coordonn�es du vertex pour l'UV
                return o;
            }

            // Fragment Shader
            half4 frag(v2f i) : SV_Target
            {
                // Calculer la position du damier bas� sur les coordonn�es UV
                float2 checker = frac(i.uv.xy / _TileSize); // Cr�e un damier en fonction de la taille des cases

                // D�cider de la couleur selon la position
                if (fmod(floor(checker.x + checker.y), 2.0) < 1.0)
                {
                    return _Color1; // Blanc
                }
                else
                {
                    return _Color2; // Noir
                }
            }
            ENDCG
        }
    }

    Fallback "Diffuse"
}