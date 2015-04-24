// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_Lightmap', a built-in variable
// Upgrade NOTE: commented out 'sampler2D unity_LightmapInd', a built-in variable
// Upgrade NOTE: replaced tex2D unity_Lightmap with UNITY_SAMPLE_TEX2D
// Upgrade NOTE: replaced tex2D unity_LightmapInd with UNITY_SAMPLE_TEX2D_SAMPLER

// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:True,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|diff-526-OUT,spec-501-OUT,gloss-678-OUT,normal-11-RGB,emission-519-OUT,amspl-694-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:33358,y:32322,ptlb:diffuse,ptin:_diffuse,tex:10590d654a4b10f4195e6978b87406b9,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3,x:34521,y:32985,ptlb:specular,ptin:_specular,tex:7b208a45c11117f4f91474cd2f3e8c4b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:11,x:33112,y:32980,ptlb:Normal,ptin:_Normal,tex:8b95fd5e0f856f14f96da8a320d99808,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Multiply,id:35,x:34048,y:32937|A-3-RGB,B-203-OUT;n:type:ShaderForge.SFN_Multiply,id:97,x:33402,y:33398|A-426-RGB,B-211-OUT;n:type:ShaderForge.SFN_Slider,id:190,x:33537,y:32477,ptlb:diffuse brightness,ptin:_diffusebrightness,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Multiply,id:191,x:33213,y:32472|A-2-RGB,B-190-OUT;n:type:ShaderForge.SFN_Slider,id:203,x:34142,y:33109,ptlb:Specular Power,ptin:_SpecularPower,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Slider,id:211,x:33205,y:33595,ptlb:reflection power,ptin:_reflectionpower,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Tex2d,id:376,x:34579,y:32687,ptlb:ao,ptin:_ao,tex:683be00786a5701428dda5f60130ed6a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:377,x:34226,y:32881,ptlb:ao power,ptin:_aopower,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:378,x:34141,y:32700|A-389-OUT,B-377-OUT;n:type:ShaderForge.SFN_Subtract,id:379,x:33869,y:32861|A-35-OUT,B-378-OUT;n:type:ShaderForge.SFN_OneMinus,id:389,x:34345,y:32697|IN-376-RGB;n:type:ShaderForge.SFN_Tex2d,id:401,x:34085,y:33329,ptlb:Emission,ptin:_Emission,tex:477de7ff5862e4546a4e66ff1e0c2946,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:412,x:33863,y:33290|A-401-RGB,B-413-OUT;n:type:ShaderForge.SFN_Slider,id:413,x:33883,y:33488,ptlb:emission power,ptin:_emissionpower,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Cubemap,id:426,x:33569,y:33552,ptlb:reflection,ptin:_reflection;n:type:ShaderForge.SFN_Vector1,id:497,x:33869,y:32505,v1:0;n:type:ShaderForge.SFN_Color,id:498,x:33882,y:32610,ptlb:SpecularColor,ptin:_SpecularColor,glob:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:499,x:33611,y:32568|A-497-OUT,B-498-RGB,T-500-RGB;n:type:ShaderForge.SFN_Tex2d,id:500,x:34039,y:32527,ptlb:SpecularTintMap,ptin:_SpecularTintMap,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:501,x:33433,y:32662|A-499-OUT,B-379-OUT;n:type:ShaderForge.SFN_Multiply,id:519,x:33739,y:33129|A-499-OUT,B-412-OUT;n:type:ShaderForge.SFN_Color,id:525,x:33108,y:32329,ptlb:DiffuseTint,ptin:_DiffuseTint,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:526,x:32981,y:32499|A-525-RGB,B-191-OUT;n:type:ShaderForge.SFN_Fresnel,id:546,x:32943,y:33478|EXP-571-OUT;n:type:ShaderForge.SFN_Lerp,id:547,x:33198,y:33252|A-97-OUT,B-650-OUT,T-546-OUT;n:type:ShaderForge.SFN_Slider,id:571,x:32930,y:33661,ptlb:fresnel falloff,ptin:_fresnelfalloff,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:650,x:33416,y:33256,ptlb:fresnel power,ptin:_fresnelpower,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Slider,id:677,x:33447,y:33009,ptlb:Gloss Power,ptin:_GlossPower,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Multiply,id:678,x:33300,y:32886|A-3-A,B-677-OUT;n:type:ShaderForge.SFN_Lerp,id:694,x:32995,y:33188|A-547-OUT,B-695-OUT,T-389-OUT;n:type:ShaderForge.SFN_Vector1,id:695,x:33190,y:33163,v1:0;proporder:2-525-190-376-377-11-3-203-500-498-401-413-426-211-571-650-677;pass:END;sub:END;*/

Shader "Shader Forge/NewShader2" {
    Properties {
        _diffuse ("diffuse", 2D) = "white" {}
        _DiffuseTint ("DiffuseTint", Color) = (1,1,1,1)
        _diffusebrightness ("diffuse brightness", Range(0, 5)) = 1
        _ao ("ao", 2D) = "white" {}
        _aopower ("ao power", Range(0, 1)) = 0
        _Normal ("Normal", 2D) = "bump" {}
        _specular ("specular", 2D) = "white" {}
        _SpecularPower ("Specular Power", Range(0, 10)) = 1
        _SpecularTintMap ("SpecularTintMap", 2D) = "white" {}
        _SpecularColor ("SpecularColor", Color) = (0,0,0,1)
        _Emission ("Emission", 2D) = "white" {}
        _emissionpower ("emission power", Range(0, 2)) = 0
        _reflection ("reflection", Cube) = "_Skybox" {}
        _reflectionpower ("reflection power", Range(0, 2)) = 0
        _fresnelfalloff ("fresnel falloff", Range(0, 1)) = 0
        _fresnelpower ("fresnel power", Range(0, 5)) = 1
        _GlossPower ("Gloss Power", Range(0, 5)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            #ifndef LIGHTMAP_OFF
                // float4 unity_LightmapST;
                // sampler2D unity_Lightmap;
                #ifndef DIRLIGHTMAP_OFF
                    // sampler2D unity_LightmapInd;
                #endif
            #endif
            uniform sampler2D _diffuse; uniform float4 _diffuse_ST;
            uniform sampler2D _specular; uniform float4 _specular_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _diffusebrightness;
            uniform float _SpecularPower;
            uniform float _reflectionpower;
            uniform sampler2D _ao; uniform float4 _ao_ST;
            uniform float _aopower;
            uniform sampler2D _Emission; uniform float4 _Emission_ST;
            uniform float _emissionpower;
            uniform samplerCUBE _reflection;
            uniform float4 _SpecularColor;
            uniform sampler2D _SpecularTintMap; uniform float4 _SpecularTintMap_ST;
            uniform float4 _DiffuseTint;
            uniform float _fresnelfalloff;
            uniform float _fresnelpower;
            uniform float _GlossPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                #ifndef LIGHTMAP_OFF
                    float2 uvLM : TEXCOORD7;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                #ifndef LIGHTMAP_OFF
                    o.uvLM = v.texcoord1 * unity_LightmapST.xy + unity_LightmapST.zw;
                #endif
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_708 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(node_708.rg, _Normal))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                #ifndef LIGHTMAP_OFF
                    float4 lmtex = UNITY_SAMPLE_TEX2D(unity_Lightmap,i.uvLM);
                    #ifndef DIRLIGHTMAP_OFF
                        float3 lightmap = DecodeLightmap(lmtex);
                        float3 scalePerBasisVector = DecodeLightmap(UNITY_SAMPLE_TEX2D_SAMPLER(unity_LightmapInd,unity_Lightmap,i.uvLM));
                        UNITY_DIRBASIS
                        half3 normalInRnmBasis = saturate (mul (unity_DirBasis, normalLocal));
                        lightmap *= dot (normalInRnmBasis, scalePerBasisVector);
                    #else
                        float3 lightmap = DecodeLightmap(lmtex);
                    #endif
                #endif
                #ifndef LIGHTMAP_OFF
                    #ifdef DIRLIGHTMAP_OFF
                        float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                    #else
                        float3 lightDirection = normalize (scalePerBasisVector.x * unity_DirBasis[0] + scalePerBasisVector.y * unity_DirBasis[1] + scalePerBasisVector.z * unity_DirBasis[2]);
                        lightDirection = mul(lightDirection,tangentTransform); // Tangent to world
                    #endif
                #else
                    float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                #endif
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                #ifndef LIGHTMAP_OFF
                    float3 diffuse = lightmap.rgb;
                #else
                    float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
                #endif
////// Emissive:
                float node_497 = 0.0;
                float3 node_499 = lerp(float3(node_497,node_497,node_497),_SpecularColor.rgb,tex2D(_SpecularTintMap,TRANSFORM_TEX(node_708.rg, _SpecularTintMap)).rgb);
                float3 emissive = (node_499*(tex2D(_Emission,TRANSFORM_TEX(node_708.rg, _Emission)).rgb*_emissionpower));
///////// Gloss:
                float4 node_3 = tex2D(_specular,TRANSFORM_TEX(node_708.rg, _specular));
                float gloss = (node_3.a*_GlossPower);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float node_695 = 0.0;
                float3 node_389 = (1.0 - tex2D(_ao,TRANSFORM_TEX(node_708.rg, _ao)).rgb);
                float3 specularColor = (node_499+((node_3.rgb*_SpecularPower)-(node_389*_aopower)));
                float3 specularAmb = lerp(lerp((texCUBE(_reflection,viewReflectDirection).rgb*_reflectionpower),float3(_fresnelpower,_fresnelpower,_fresnelpower),pow(1.0-max(0,dot(normalDirection, viewDirection)),_fresnelfalloff)),float3(node_695,node_695,node_695),node_389) * specularColor;
                float3 specular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor + specularAmb;
                #ifndef LIGHTMAP_OFF
                    #ifndef DIRLIGHTMAP_OFF
                        specular *= lightmap;
                    #else
                        specular *= (floor(attenuation) * _LightColor0.xyz);
                    #endif
                #else
                    specular *= (floor(attenuation) * _LightColor0.xyz);
                #endif
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * (_DiffuseTint.rgb*(tex2D(_diffuse,TRANSFORM_TEX(node_708.rg, _diffuse)).rgb*_diffusebrightness));
                finalColor += specular;
                finalColor += emissive;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            #ifndef LIGHTMAP_OFF
                // float4 unity_LightmapST;
                // sampler2D unity_Lightmap;
                #ifndef DIRLIGHTMAP_OFF
                    // sampler2D unity_LightmapInd;
                #endif
            #endif
            uniform sampler2D _diffuse; uniform float4 _diffuse_ST;
            uniform sampler2D _specular; uniform float4 _specular_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _diffusebrightness;
            uniform float _SpecularPower;
            uniform sampler2D _ao; uniform float4 _ao_ST;
            uniform float _aopower;
            uniform sampler2D _Emission; uniform float4 _Emission_ST;
            uniform float _emissionpower;
            uniform float4 _SpecularColor;
            uniform sampler2D _SpecularTintMap; uniform float4 _SpecularTintMap_ST;
            uniform float4 _DiffuseTint;
            uniform float _GlossPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float2 node_709 = i.uv0;
                float3 normalLocal = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(node_709.rg, _Normal))).rgb;
                float3 normalDirection =  normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
///////// Gloss:
                float4 node_3 = tex2D(_specular,TRANSFORM_TEX(node_709.rg, _specular));
                float gloss = (node_3.a*_GlossPower);
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float node_497 = 0.0;
                float3 node_499 = lerp(float3(node_497,node_497,node_497),_SpecularColor.rgb,tex2D(_SpecularTintMap,TRANSFORM_TEX(node_709.rg, _SpecularTintMap)).rgb);
                float3 node_389 = (1.0 - tex2D(_ao,TRANSFORM_TEX(node_709.rg, _ao)).rgb);
                float3 specularColor = (node_499+((node_3.rgb*_SpecularPower)-(node_389*_aopower)));
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * (_DiffuseTint.rgb*(tex2D(_diffuse,TRANSFORM_TEX(node_709.rg, _diffuse)).rgb*_diffusebrightness));
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
