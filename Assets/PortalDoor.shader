// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33426,y:32733,varname:node_1873,prsc:2|emission-1749-OUT,alpha-4805-A;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32580,y:32729,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:e1cb796c61028354f8cf8cc02b61f874,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32812,y:32818,cmnt:RGB,varname:node_1086,prsc:2|A-3574-RGB,B-5983-RGB,C-5376-RGB,D-9686-OUT;n:type:ShaderForge.SFN_Color,id:5983,x:32551,y:32915,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32551,y:33079,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33007,y:32897,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32812,y:33013,cmnt:A,varname:node_603,prsc:2|A-3574-A,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_TexCoord,id:4587,x:31792,y:32817,varname:node_4587,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4046,x:32172,y:32817,varname:node_4046,prsc:2,spu:0.2,spv:-0.2|UVIN-6027-UVOUT,DIST-809-T;n:type:ShaderForge.SFN_Time,id:809,x:32052,y:32621,varname:node_809,prsc:2;n:type:ShaderForge.SFN_Add,id:4968,x:32374,y:32511,varname:node_4968,prsc:2|A-877-OUT,B-809-TDB;n:type:ShaderForge.SFN_FragmentPosition,id:1177,x:31978,y:32441,varname:node_1177,prsc:2;n:type:ShaderForge.SFN_Sin,id:2380,x:32533,y:32511,varname:node_2380,prsc:2|IN-4968-OUT;n:type:ShaderForge.SFN_Multiply,id:877,x:32195,y:32456,varname:node_877,prsc:2|A-9844-OUT,B-1177-Y;n:type:ShaderForge.SFN_Vector1,id:9844,x:32026,y:32347,varname:node_9844,prsc:2,v1:4;n:type:ShaderForge.SFN_Panner,id:6027,x:31997,y:32817,varname:node_6027,prsc:2,spu:0.2,spv:0.075|UVIN-4587-UVOUT,DIST-2380-OUT;n:type:ShaderForge.SFN_HsvToRgb,id:9686,x:32777,y:32626,varname:node_9686,prsc:2|H-809-TSL,S-8658-OUT,V-8658-OUT;n:type:ShaderForge.SFN_Vector1,id:8658,x:32695,y:32483,varname:node_8658,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:3574,x:32354,y:33011,ptovrint:False,ptlb:BGTex,ptin:_BGTex,varname:node_3574,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5af73a27703af1841a521eac37d2253d,ntxv:0,isnm:False|UVIN-75-OUT;n:type:ShaderForge.SFN_Multiply,id:75,x:32354,y:32795,varname:node_75,prsc:2|A-5731-PXWH,B-4046-UVOUT,C-607-OUT;n:type:ShaderForge.SFN_Vector1,id:607,x:32172,y:32973,varname:node_607,prsc:2,v1:60;n:type:ShaderForge.SFN_PixelSize,id:5731,x:32195,y:32621,varname:node_5731,prsc:2;proporder:4805-5983-3574;pass:END;sub:END;*/

Shader "Shader Forge/PortalDoor" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "black" {}
        _Color ("Color", Color) = (1,1,1,1)
        _BGTex ("BGTex", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        _Stencil ("Stencil ID", Float) = 0
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilComp ("Stencil Comparison", Float) = 8
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilOpFail ("Stencil Fail Operation", Float) = 0
        _StencilOpZFail ("Stencil Z-Fail Operation", Float) = 0
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
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            Stencil {
                Ref [_Stencil]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilOp]
                Fail [_StencilOpFail]
                ZFail [_StencilOpZFail]
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BGTex; uniform float4 _BGTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 node_809 = _Time;
                float2 node_75 = (float2( _ScreenParams.z-1, _ScreenParams.w-1 ).rg*((i.uv0+sin(((4.0*i.posWorld.g)+node_809.b))*float2(0.2,0.075))+node_809.g*float2(0.2,-0.2))*60.0);
                float4 _BGTex_var = tex2D(_BGTex,TRANSFORM_TEX(node_75, _BGTex));
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float node_8658 = 1.0;
                float node_603 = (_BGTex_var.a*_Color_var.a*i.vertexColor.a); // A
                float3 emissive = ((_BGTex_var.rgb*_Color_var.rgb*i.vertexColor.rgb*(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_809.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_8658)*node_8658))*node_603);
                float3 finalColor = emissive;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                return fixed4(finalColor,_MainTex_var.a);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
