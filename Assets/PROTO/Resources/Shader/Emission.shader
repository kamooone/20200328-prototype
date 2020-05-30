//////////////////////////////////////////////////////
//発光させる Ver1
////////////////////////////////////////////////////////
Shader "Custom/Emission"
{
	//プロパティ
	Properties
	{
		//マテリアルの色
		_Color("Main Color", Color) = (0.5,0.5,0.5,1)

		//テクスチャ
		_MainTex("Albedo (RGB)", 2D) = "white" {}

		//エミッションカラー
		_EmissionColor("Emmission Color",Color) = (1.0,1.0,1.0,1.0)//発光色

		//ランプテクスチャ
		_RampTex("RampTexture",2D) = "white"{}

		//アウトラインカラー
		_OutlineColor("Outline color", Color) = (1,0,0,255.0)
	
		//アウトライン太さ
		_OutlineWidth("Outlines width", Range(0.0, 2.0)) = 00.15
	}

		//ビルドインのインクルード(CGPROGRAM)
		CGINCLUDE
#include "UnityCG.cginc"

		//
		struct appdata {
		float4 vertex : POSITION;
		float4 normal : NORMAL;
	};

	//モデルプロパティの参照
	uniform float4 _Color;
	uniform sampler2D _MainTex;
	uniform sampler2D _RampTex;

	//アウトラインプロパティの参照
	uniform float4 _OutlineColor;
	uniform float _OutlineWidth;

	//cg言語書き終わり
	ENDCG

		//メインシェーダ
		SubShader{

		//共通のState
		LOD 200

		//アウトライン描画
		Pass{

		//タグ付
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }

		//ブレンドモード設定
		Blend SrcAlpha OneMinusSrcAlpha

		//Zバッファオフ
		ZWrite Off

		//背面描画
		Cull Back

		//cg言語書き始め
		CGPROGRAM

		//
		struct v2f {
		float4 pos : SV_POSITION;
	};

	//バーテックスシェーダ使用
#pragma vertex vert

	//フラグメントシェーダ使用
#pragma fragment frag


	//バーテックスシェーダ処理
	v2f vert(appdata v) {

		//
		appdata original = v;

		//
		float3 scaleDir = normalize(v.vertex.xyz - float4(0,0,0,1));

		//ほんとは角度を見ていろいろするけど正面からしか見ないので省略
		v.vertex.xyz += scaleDir * _OutlineWidth;

		//
		v2f o;

		//
		o.pos = UnityObjectToClipPos(v.vertex);

		//
		return o;
	}

	//フラグメントシェーダ処理
	half4 frag(v2f i) : COLOR{
		return _OutlineColor;
	}

		//cg言語書き終わり
		ENDCG
	}


		//タグ付け
		Tags{ "Queue" = "Transparent" }

		//cg言語書き始め
		CGPROGRAM


#pragma surface surf ToonRamp

		//emissionの色
		half4 _EmissionColor;

		struct Input {
		float2 uv_MainTex;
		float4 color : COLOR;
	};


	fixed4 LightingToonRamp(SurfaceOutput s, fixed3 lightDir, fixed atten) {
		half d = dot(s.Normal, lightDir)*0.5 + 0.5;
		fixed3 ramp = tex2D(_RampTex, fixed2(d, 0.5)).rgb;
		fixed4 c;
		c.rgb = s.Albedo* _LightColor0.rgb*ramp;
		c.a = 0;
		return c;
	}


	//サーフェスシェーダ処理
	void surf(Input IN, inout SurfaceOutput  o) {
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
		o.Emission = _EmissionColor;
	}

	//cg言語書き終わり
	ENDCG
	}

		//処理できないならDiffuseを使う
		Fallback "Diffuse"
}

