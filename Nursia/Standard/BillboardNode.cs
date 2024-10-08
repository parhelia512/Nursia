﻿using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Nursia.Attributes;
using System.ComponentModel;

namespace Nursia.Standard
{
	[EditorInfo("Billboard")]
	public class BillboardNode : BillboardNodeBase
	{
		private Texture2D _texture;

		[Browsable(false)]
		[JsonIgnore]
		public Texture2D Texture
		{
			get => _texture;

			set
			{
				if (value == _texture)
				{
					return;
				}

				_texture = value;
				InvalidateBinding();
			}
		}

		protected override Texture2D RenderTexture => Texture;
	}
}