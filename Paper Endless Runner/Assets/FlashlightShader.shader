Shader "Custom/FlashlightShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PlayerPosition("Player Position", Vector) = (0,0,0,1)
        _LightRadius("Light Radius", Float) = 5.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _PlayerPosition;
            float _LightRadius;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float3 worldPos = mul(unity_ObjectToWorld, float4(i.uv, 0, 1)).xyz;
                float dist = distance(worldPos, _PlayerPosition.xyz);

                // Calculate brightness based on distance
                float brightness = saturate(1.0 - (dist / _LightRadius));

                // Sample texture and apply brightness
                half4 texColor = tex2D(_MainTex, i.uv);
                return texColor * brightness;
            }
            ENDCG
        }
    }
}
