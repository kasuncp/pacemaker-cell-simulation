Shader "Custom/CellShader"
{
    Properties {
        _Charge ("Charge", Float) = 0
    }

    SubShader
    {
        CGPROGRAM
        #pragma surface ConfigureSurface Standard fullforwardshadows
        #pragma target 3.0

        struct Input {
			float3 worldPos;
		};

        float _Charge;

        void ConfigureSurface (Input input, inout SurfaceOutputStandard surface) {
            surface.Albedo = float3(_Charge * 0.01 , 0, 1 - _Charge * 0.01);
        }

		ENDCG
    }

    FallBack "Diffuse"
}
