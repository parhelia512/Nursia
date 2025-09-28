using DigitalRiseModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nursia.Primitives
{
	public static partial class PrimitiveMeshes
	{
		private static readonly ushort[] _cubeIndices =
		{
			0, 1, 3, 1, 2, 3, 1, 5, 2,
			2, 5, 6, 4, 7, 5, 5, 7, 6,
			0, 3, 4, 4, 3, 7, 7, 3, 6,
			6, 3, 2, 4, 5, 0, 0, 5, 1
		};

		private static readonly ushort[] _squareIndices =
		{
			0, 1, 2, 3, 4, 5
		};

		private static Vector3[] _cubeFromMinusOneToOne = new Vector3[]
		{
			new Vector3(-1, 1, 1),
			new Vector3(1, 1, 1),
			new Vector3(1, -1, 1),
			new Vector3(-1, -1, 1),
			new Vector3(-1, 1, -1),
			new Vector3(1, 1, -1),
			new Vector3(1, -1, -1),
			new Vector3(-1, -1,-1)
		};

		private static Vector3[] _cubeFromZeroToOne = new Vector3[]
		{
			new Vector3(0, 1, 1),
			new Vector3(1, 1, 1),
			new Vector3(1, 0, 1),
			new Vector3(0, 0, 1),
			new Vector3(0, 1, 0),
			new Vector3(1, 1, 0),
			new Vector3(1, 0, 0),
			new Vector3(0, 0, 0)
		};

		private static Vector3[] _squareFromMinusOneToOne = new Vector3[]
		{
				new Vector3(-1, 0, -1),
				new Vector3(-1, 0, 1),
				new Vector3(1, 0, -1),
				new Vector3(1, 0, -1),
				new Vector3(-1, 0, 1),
				new Vector3(1, 0, 1)
		};

		private static Vector3[] _squareFromZeroToOne = new Vector3[]
		{
				new Vector3(0, 0, 0),
				new Vector3(0, 0, 1),
				new Vector3(1, 0, 0),
				new Vector3(1, 0, 0),
				new Vector3(0, 0, 1),
				new Vector3(1, 0, 1)
		};

		private static VertexPositionTexture[] _squarePositionTextureFromZeroToOneData = new VertexPositionTexture[]
		{
				new VertexPositionTexture(new Vector3(0, 0, 0), Vector2.Zero),
				new VertexPositionTexture(new Vector3(0, 0, 1), new Vector2(0, 1)),
				new VertexPositionTexture(new Vector3(1, 0, 0), new Vector2(1, 0)),
				new VertexPositionTexture(new Vector3(1, 0, 0),new Vector2(1, 0)),
				new VertexPositionTexture(new Vector3(0, 0, 1),new Vector2(0, 1)),
				new VertexPositionTexture(new Vector3(1, 0, 1), new Vector2(1, 1))
		};

		private static DrMeshPart _cubePosition;
		private static DrMeshPart _squarePositionFromZeroToOne;
		private static DrMeshPart _squarePositionTextureFromZeroToOne;

		public static DrMeshPart CubePositionFromMinusOneToOne
		{
			get
			{
				if (_cubePosition == null)
				{
					_cubePosition = CreatePrimitivePosition(_cubeFromMinusOneToOne, _cubeIndices);
				}

				return _cubePosition;
			}
		}

		public static DrMeshPart CubePositionFromZeroToOne
		{
			get
			{
				if (_cubePosition == null)
				{
					_cubePosition = CreatePrimitivePosition(_cubeFromZeroToOne, _cubeIndices);
				}

				return _cubePosition;
			}
		}

		public static DrMeshPart SquarePositionFromMinusOneToOne
		{
			get
			{
				if (_squarePositionTextureFromZeroToOne == null)
				{
					_squarePositionTextureFromZeroToOne = CreatePrimitivePosition(_squareFromMinusOneToOne, _squareIndices);
				}

				return _squarePositionTextureFromZeroToOne;
			}
		}

		public static DrMeshPart SquarePositionFromZeroToOne
		{
			get
			{
				if (_squarePositionFromZeroToOne == null)
				{
					_squarePositionFromZeroToOne = CreatePrimitivePosition(_squareFromZeroToOne, _squareIndices);
				}

				return _squarePositionFromZeroToOne;
			}
		}

		public static DrMeshPart SquarePositionTextureFromZeroToOne
		{
			get
			{
				if (_squarePositionTextureFromZeroToOne == null)
				{
					_squarePositionTextureFromZeroToOne = new DrMeshPart(Nrs.GraphicsDevice, _squarePositionTextureFromZeroToOneData, _squareIndices);
				}

				return _squarePositionTextureFromZeroToOne;
			}
		}

		private static DrMeshPart CreatePrimitivePosition(Vector3[] positions, ushort[] indices)
		{
			return new DrMeshPart(Nrs.GraphicsDevice, positions, indices);
		}
	}
}