// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33028,y:32655,varname:node_3138,prsc:2|emission-786-OUT;n:type:ShaderForge.SFN_Sin,id:3956,x:32670,y:32667,varname:node_3956,prsc:2|IN-4305-OUT;n:type:ShaderForge.SFN_Time,id:4453,x:32108,y:32822,varname:node_4453,prsc:2;n:type:ShaderForge.SFN_HsvToRgb,id:786,x:32807,y:32837,varname:node_786,prsc:2|H-3956-OUT,S-4670-OUT,V-4670-OUT;n:type:ShaderForge.SFN_Vector1,id:4670,x:32261,y:32625,varname:node_4670,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:4305,x:32572,y:32867,varname:node_4305,prsc:2|A-4293-OUT,B-8227-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:9957,x:32239,y:32961,varname:node_9957,prsc:2;n:type:ShaderForge.SFN_Vector1,id:1130,x:32261,y:32701,varname:node_1130,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:8227,x:32549,y:33016,varname:node_8227,prsc:2|A-9957-X,B-1130-OUT,C-2874-OUT;n:type:ShaderForge.SFN_ObjectScale,id:3559,x:32219,y:33123,varname:node_3559,prsc:2,rcp:False;n:type:ShaderForge.SFN_Reciprocal,id:2874,x:32445,y:33133,varname:node_2874,prsc:2|IN-3559-X;n:type:ShaderForge.SFN_Vector1,id:6065,x:32198,y:32765,varname:node_6065,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:4293,x:32372,y:32838,varname:node_4293,prsc:2|A-4453-T,B-6065-OUT;pass:END;sub:END;*/

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
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
////// Lighting:
////// Emissive:
                float4 node_4453 = _Time;
                float node_4670 = 1.0;
                float3 emissive = (lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(sin(((node_4453.g*0.2)+(i.posWorld.r*1.0*(1.0 / objScale.r))))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_4670)*node_4670);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
