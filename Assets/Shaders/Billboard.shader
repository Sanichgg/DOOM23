Shader "Billboard/1Directional"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _SecondTex ("SecondTexture", Float) = 1
    }
    SubShader
    {
        Tags 
        {  
        "RenderType"="Opaque" 
        "DisableBatching" = "True" 
        }
        LOD 100


        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "DoomBillboard.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float angle : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            

            v2f vert (appdata v)
            {
                v2f o;

                //o.vertex = mul(UNITY_MATRIX_VP, mul(unity_ObjectToWorld, v.vertex));

                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normal = v.normal;

                //https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Camera-Node.html
                float3 cameraDir = -1 * mul(UNITY_MATRIX_M, transpose(mul(unity_WorldToObject, UNITY_MATRIX_I_V))[2].xyz);
                cameraDir.y = 0;

                float2 cameraDir2D = normalize(cameraDir.xz);

                float2 vectorForward2D = mul(UNITY_MATRIX_M, float4(0,0,1,0)).xz;

                float angle = dot(vectorForward2D, cameraDir2D);

                float angleRad = acos(angle);

                

                float3 crossProduct = cross(
                    float3(vectorForward2D.x, 0, vectorForward2D.y),
                    float3(cameraDir.x, 0, cameraDir.y));

                if(dot(crossProduct, float3(0,1,0)) < 0)
                    angleRad = -angleRad;

                float angleNormalized = angleRad / 3.1415;



                o.angle = (angleNormalized + 1) / 2;


                float3 newVertex;
                Unity_RotateAboutAxis_Radians_float(v.vertex, float3(0,1,0), angleRad, newVertex);

                o.vertex = UnityObjectToClipPos(newVertex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 color = tex2D(_MainTex, i.uv);

                if(color.a < 0.001)
                    discard;

                return color;
            }
            ENDCG
        }
    }
}
