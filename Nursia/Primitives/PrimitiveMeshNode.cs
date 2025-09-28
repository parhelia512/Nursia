using DigitalRiseModel;
using Nursia.Standard;
using Nursia.Utilities;

namespace Nursia.Primitives
{
	public abstract class PrimitiveMeshNode: MeshNodeBase
	{
		private bool _isLeftHanded;
		private DrMeshPart _mesh;
		private float _uScale = 1.0f;
		private float _vScale = 1.0f;

		protected override DrMeshPart RenderMesh
		{
			get
			{
				if (_mesh == null)
				{
					_mesh = CreateMesh();
				}

				return _mesh;
			}
		}

		public bool IsLeftHanded
		{
			get => _isLeftHanded;

			set
			{
				if (value == _isLeftHanded)
				{
					return;
				}

				_isLeftHanded = value;
				InvalidateMesh();
			}
		}

		public float UScale
		{
			get => _uScale;

			set
			{
				if (value.EpsilonEquals(_uScale))
				{
					return;
				}

				_uScale = value;
				InvalidateMesh();
			}
		}

		public float VScale
		{
			get => _vScale;

			set
			{
				if (value.EpsilonEquals(_vScale))
				{
					return;
				}

				_vScale = value;
				InvalidateMesh();
			}
		}

		protected abstract DrMeshPart CreateMesh();

		public void InvalidateMesh()
		{
			_mesh = null;
		}
	}
}