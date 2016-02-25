// Shader created with Shader Forge v1.17 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.17;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1873,x:33229,y:32719,varname:node_1873,prsc:2|emission-1749-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:31880,y:32726,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:6dc9c92d8e934e64bbbf8aa7df7c6892,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32844,y:32818,cmnt:RGB,varname:node_1086,prsc:2|A-3933-OUT,B-5983-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32319,y:32970,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:1749,x:33025,y:32818,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32812,y:32992,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A;n:type:ShaderForge.SFN_Tex2d,id:8480,x:31773,y:32146,ptovrint:False,ptlb:Tex2,ptin:_Tex2,varname:node_8480,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6abbe9035a6ca6643b52f381834785c4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:113,x:32100,y:32354,varname:node_113,prsc:2,blmd:5,clmp:True|SRC-8480-RGB,DST-8040-RGB;n:type:ShaderForge.SFN_Color,id:8040,x:31773,y:32339,ptovrint:False,ptlb:Text2Influence,ptin:_Text2Influence,varname:node_8040,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:9943,x:32041,y:32162,ptovrint:False,ptlb:Text3Influence,ptin:_Text3Influence,varname:_node_8040_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8,c2:0.8,c3:0.8,c4:1;n:type:ShaderForge.SFN_Tex2d,id:3527,x:32041,y:31969,ptovrint:False,ptlb:Tex3,ptin:_Tex3,varname:_Tex3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:83bf1f795d527c04b8209e57a072b3ff,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Blend,id:1223,x:32244,y:32097,varname:node_1223,prsc:2,blmd:5,clmp:True|SRC-3527-RGB,DST-9943-RGB;n:type:ShaderForge.SFN_Multiply,id:3933,x:32568,y:32584,varname:node_3933,prsc:2|A-1223-OUT,B-113-OUT,C-4877-OUT;n:type:ShaderForge.SFN_Color,id:8198,x:31975,y:32555,ptovrint:False,ptlb:Text1Influence,ptin:_Text1Influence,varname:_Text2Influence_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Blend,id:4877,x:32216,y:32670,varname:node_4877,prsc:2,blmd:5,clmp:True|SRC-4805-RGB,DST-8198-RGB;proporder:4805-5983-8198-8480-8040-3527-9943;pass:END;sub:END;*/

Shader "Shader Forge/Temblque" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Text1Influence ("Text1Influence", Color) = (0,0,0,1)
        _Tex2 ("Tex2", 2D) = "white" {}
        _Text2Influence ("Text2Influence", Color) = (0.5,0.5,0.5,1)
        _Tex3 ("Tex3", 2D) = "white" {}
        _Text3Influence ("Text3Influence", Color) = (0.8,0.8,0.8,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform sampler2D _Tex2; uniform float4 _Tex2_ST;
            uniform float4 _Text2Influence;
            uniform float4 _Text3Influence;
            uniform sampler2D _Tex3; uniform float4 _Tex3_ST;
            uniform float4 _Text1Influence;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float4 _Tex3_var = tex2D(_Tex3,TRANSFORM_TEX(i.uv0, _Tex3));
                float4 _Tex2_var = tex2D(_Tex2,TRANSFORM_TEX(i.uv0, _Tex2));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_603 = (_MainTex_var.a*_Color.a); // A
                float3 emissive = (((saturate(max(_Tex3_var.rgb,_Text3Influence.rgb))*saturate(max(_Tex2_var.rgb,_Text2Influence.rgb))*saturate(max(_MainTex_var.rgb,_Text1Influence.rgb)))*_Color.rgb)*node_603);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
