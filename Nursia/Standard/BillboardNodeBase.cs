﻿using DigitalRiseModel;
using DigitalRiseModel.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Nursia.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace Nursia.Standard
{
	public class BillboardEffectBinding : EffectBinding
	{
		public EffectParameter Width { get; set; }
		public EffectParameter Height { get; set; }
		public EffectParameter Color { get; set; }
		public EffectParameter Texture { get; set; }

		protected override void BindParameters()
		{
			base.BindParameters();

			Width = Effect.Parameters["_width"];
			Height = Effect.Parameters["_height"];
			Color = Effect.Parameters["_color"];
			Texture = Effect.Parameters["_texture"];
		}
	}

	public abstract class BillboardNodeBase : SceneNode, IMaterial
	{
		private static DrMeshPart _mesh;
		private BillboardEffectBinding _effectBinding;

		public Color Color { get; set; } = Color.White;

		private static DrMeshPart Mesh
		{
			get
			{
				if (_mesh == null)
				{
					_mesh = MeshPrimitives.CreatePlaneMeshPart(Nrs.GraphicsDevice);
				}

				return _mesh;
			}
		}

		[Browsable(false)]
		[JsonIgnore]
		public EffectBinding EffectBinding
		{
			get
			{
				if (_effectBinding == null)
				{
					if (RenderTexture == null)
					{
						_effectBinding = EffectsRegistry.GetStockEffectBinding<BillboardEffectBinding>("BillboardEffect");
					}
					else
					{
						_effectBinding = EffectsRegistry.GetStockEffectBinding<BillboardEffectBinding>("BillboardEffect",
							new Dictionary<string, string>
							{
								["TEXTURE"] = "1"
							});
					}
				}

				return _effectBinding;
			}
		}

		[Browsable(false)]
		[JsonIgnore]
		public EffectBinding ShadowMapEffect => null;

		[DefaultValue(NodeBlendMode.Transparent)]
		public NodeBlendMode BlendMode { get; set; } = NodeBlendMode.Transparent;

		public bool CastsShadows => false;

		public bool ReceivesShadows => false;

		protected float Width { get; set; } = 1.0f;
		protected float Height { get; set; } = 1.0f;
		protected abstract Texture2D RenderTexture { get; }

		protected internal override void Render(RenderBatch batch)
		{
			base.Render(batch);

			batch.BatchJob(this, GlobalTransform, Mesh);
		}

		protected void InvalidateBinding()
		{
			_effectBinding = null;
		}

		public void SetParameters()
		{
			_effectBinding.Width.SetValue(Width);
			_effectBinding.Height.SetValue(Height);
			_effectBinding.Color.SetValue(Color.ToVector4());
			_effectBinding.Texture?.SetValue(RenderTexture);
		}
	}
}