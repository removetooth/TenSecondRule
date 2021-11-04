// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33028,y:32655,varname:node_3138,prsc:2|emission-786-OUT,voffset-9136-OUT;n:type:ShaderForge.SFN_Time,id:4453,x:32108,y:32822,varname:node_4453,prsc:2;n:type:ShaderForge.SFN_HsvToRgb,id:786,x:32807,y:32837,varname:node_786,prsc:2|H-4305-OUT,S-5499-OUT,V-4670-OUT;n:type:ShaderForge.SFN_Vector1,id:4670,x:32327,y:32639,varname:node_4670,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Add,id:4305,x:32592,y:32864,varname:node_4305,prsc:2|A-4293-OUT,B-8227-OUT,C-2082-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:9957,x:32071,y:32952,varname:node_9957,prsc:2;n:type:ShaderForge.SFN_Vector1,id:1130,x:32261,y:32701,varname:node_1130,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:8227,x:32536,y:33023,varname:node_8227,prsc:2|A-8469-OUT,B-1130-OUT,C-3559-X;n:type:ShaderForge.SFN_ObjectScale,id:3559,x:32117,y:33227,varname:node_3559,prsc:2,rcp:True;n:type:ShaderForge.SFN_Vector1,id:6065,x:32198,y:32765,varname:node_6065,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:4293,x:32372,y:32838,varname:node_4293,prsc:2|A-4453-T,B-6065-OUT;n:type:ShaderForge.SFN_NormalVector,id:1937,x:32661,y:33321,prsc:2,pt:False;n:type:ShaderForge.SFN_Vector3,id:877,x:32691,y:33194,varname:node_877,prsc:2,v1:1,v2:1,v3:1;n:type:ShaderForge.SFN_Multiply,id:9136,x:33010,y:33232,varname:node_9136,prsc:2|A-877-OUT,B-1937-OUT,C-5070-OUT;n:type:ShaderForge.SFN_Sin,id:8941,x:32563,y:33501,varname:node_8941,prsc:2|IN-252-OUT;n:type:ShaderForge.SFN_Subtract,id:8157,x:32851,y:33499,varname:node_8157,prsc:2|A-8941-OUT,B-7612-OUT;n:type:ShaderForge.SFN_Vector1,id:7612,x:32575,y:33635,varname:node_7612,prsc:2,v1:-0.9;n:type:ShaderForge.SFN_Vector1,id:9577,x:32851,y:33626,varname:node_9577,prsc:2,v1:0;n:type:ShaderForge.SFN_Min,id:5070,x:33036,y:33499,varname:node_5070,prsc:2|A-8157-OUT,B-9577-OUT;n:type:ShaderForge.SFN_Add,id:252,x:32357,y:33501,varname:node_252,prsc:2|A-4453-T,B-7445-OUT;n:type:ShaderForge.SFN_Multiply,id:7445,x:32176,y:33501,varname:node_7445,prsc:2|A-6275-OUT,B-3559-Y;n:type:ShaderForge.SFN_Negate,id:6275,x:32415,y:33279,varname:node_6275,prsc:2|IN-8791-OUT;n:type:ShaderForge.SFN_ObjectPosition,id:1815,x:32071,y:33083,varname:node_1815,prsc:2;n:type:ShaderForge.SFN_Subtract,id:8469,x:32272,y:32964,varname:node_8469,prsc:2|A-9957-X,B-1815-X;n:type:ShaderForge.SFN_Subtract,id:8791,x:32272,y:33101,varname:node_8791,prsc:2|A-9957-Y,B-1815-Y;n:type:ShaderForge.SFN_Multiply,id:6670,x:32536,y:33151,varname:node_6670,prsc:2|A-8791-OUT,B-1130-OUT,C-3559-Y;n:type:ShaderForge.SFN_Negate,id:479,x:32691,y:33063,varname:node_479,prsc:2|IN-6670-OUT;n:type:ShaderForge.SFN_Divide,id:2082,x:32865,y:33094,varname:node_2082,prsc:2|A-479-OUT,B-8973-OUT;n:type:ShaderForge.SFN_Vector1,id:8973,x:32718,y:32979,varname:node_8973,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:5499,x:32327,y:32582,varname:node_5499,prsc:2,v1:0.8;pass:END;sub:END;*/

Shader "Shader Forge/NewShader" {
    Properties {
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float4 node_4453 = _Time;
                float node_8791 = (mul(unity_ObjectToWorld, v.vertex).g-objPos.g);
                v.vertex.xyz += (float3(1,1,1)*v.normal*min((sin((node_4453.g+((-1*node_8791)*recipObjScale.g)))-(-0.9)),0.0));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 node_4453 = _Time;
                float node_1130 = 0.2;
                float node_8791 = (i.posWorld.g-objPos.g);
                float3 emissive = (lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(((node_4453.g*0.2)+((i.posWorld.r-objPos.r)*node_1130*recipObjScale.r)+((-1*(node_8791*node_1130*recipObjScale.g))/0.5))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),0.8)*0.8);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float4 node_4453 = _Time;
                float node_8791 = (mul(unity_ObjectToWorld, v.vertex).g-objPos.g);
                v.vertex.xyz += (float3(1,1,1)*v.normal*min((sin((node_4453.g+((-1*node_8791)*recipObjScale.g)))-(-0.9)),0.0));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
