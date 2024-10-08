//-----------------------------------------------------------------------------
// Macros.fxh
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

#ifdef SM4

// Macros for targetting shader model 4.0 (DX11)

#define TECHNIQUE(name, vsname, psname ) \
	technique name { pass { VertexShader = compile vs_4_0 vsname (); PixelShader = compile ps_4_0 psname(); } }

#define BEGIN_CONSTANTS     cbuffer Parameters : register(b0) {
#define MATRIX_CONSTANTS
#define END_CONSTANTS       };

#define _vs(r)
#define _ps(r)
#define _cb(r)

#define DECLARE_TEXTURE(Name, index) \
	Texture2D<float4> Name : register(t##index); \
	sampler Name##Sampler : register(s##index)

#define DECLARE_CUBEMAP(Name, index) \
	TextureCube<float4> Name : register(t##index); \
	sampler Name##Sampler : register(s##index)

#define SAMPLE_TEXTURE(Name, texCoord)  Name.Sample(Name##Sampler, texCoord)
#define SAMPLE_CUBEMAP(Name, texCoord)  Name.Sample(Name##Sampler, texCoord)


#else


// Macros for targetting shader model 3.0 (mojoshader)

#define TECHNIQUE(name, vsname, psname ) \
	technique name { pass { VertexShader = compile vs_3_0 vsname (); PixelShader = compile ps_3_0 psname(); } }

#define BEGIN_CONSTANTS
#define MATRIX_CONSTANTS
#define END_CONSTANTS

#define _vs(r)  : register(vs, r)
#define _ps(r)  : register(ps, r)
#define _cb(r)

#define DECLARE_TEXTURE_LINEAR_CLAMP(Name) \
	texture2D Name; \
	sampler Name##Sampler = sampler_state { Texture = (Name); MipFilter = LINEAR; MinFilter = LINEAR; MagFilter = LINEAR; AddressU = Clamp; AddressV = Clamp; };

#define DECLARE_TEXTURE_LINEAR_WRAP(Name) \
	texture2D Name; \
	sampler Name##Sampler = sampler_state { Texture = (Name); MipFilter = LINEAR; MinFilter = LINEAR; MagFilter = LINEAR; AddressU = Wrap; AddressV = Wrap; };

#define DECLARE_TEXTURE_POINT_CLAMP(Name) \
	texture2D Name; \
	sampler Name##Sampler = sampler_state { Texture = (Name); MipFilter = POINT; MinFilter = POINT; MagFilter = POINT; AddressU = Clamp; AddressV = Clamp; };

#define DECLARE_TEXTURE_POINT_WRAP(Name) \
	texture2D Name; \
	sampler Name##Sampler = sampler_state { Texture = (Name); MipFilter = POINT; MinFilter = POINT; MagFilter = POINT; AddressU = Wrap; AddressV = Wrap; };

#define DECLARE_CUBEMAP_LINEAR_CLAMP(Name) \
	textureCUBE Name; \
	sampler Name##Sampler = sampler_state { Texture = (Name); MipFilter = LINEAR; MinFilter = LINEAR; MagFilter = LINEAR; AddressU = Clamp; AddressV = Clamp; };

#define SAMPLE_TEXTURE(Name, texCoord)  tex2D(Name##Sampler, texCoord)
#define SAMPLE_CUBEMAP(Name, texCoord)  texCUBE(Name##Sampler, texCoord)

#endif
