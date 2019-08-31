/* Generated by MyraPad at 31.08.2019 23:50:22 */
using Myra.Graphics2D.UI;

#if !XENKO
using Microsoft.Xna.Framework;
#else
using Xenko.Core.Mathematics;
#endif

namespace ModelViewer.UI
{
	partial class MainPanel
	{
		private void BuildUI()
		{
			var textBlock1 = new TextBlock();
			textBlock1.Text = "Model";

			_textPath = new TextField();
			_textPath.Text = "";
			_textPath.Readonly = true;
			_textPath.Id = "_textPath";
			_textPath.Width = 400;
			_textPath.GridColumn = 1;

			_buttonBrowse = new TextButton();
			_buttonBrowse.Text = "Open...";
			_buttonBrowse.Id = "_buttonBrowse";
			_buttonBrowse.GridColumn = 2;

			var textBlock2 = new TextBlock();
			textBlock2.Text = "Animations";
			textBlock2.GridRow = 1;

			var listItem1 = new ListItem();
			listItem1.Id = null;
			listItem1.Text = null;

			var listItem2 = new ListItem();
			listItem2.Id = null;
			listItem2.Text = "Move";

			var listItem3 = new ListItem();
			listItem3.Id = null;
			listItem3.Text = "Attack";

			_comboAnimations = new ComboBox();
			_comboAnimations.Id = "_comboAnimations";
			_comboAnimations.GridColumn = 1;
			_comboAnimations.GridRow = 1;
			_comboAnimations.Items.Add(listItem1);
			_comboAnimations.Items.Add(listItem2);
			_comboAnimations.Items.Add(listItem3);

			var grid1 = new Grid();
			grid1.ColumnSpacing = 8;
			grid1.RowSpacing = 8;
			grid1.ColumnsProportions.Add(new Grid.Proportion());
			grid1.ColumnsProportions.Add(new Grid.Proportion());
			grid1.ColumnsProportions.Add(new Grid.Proportion());
			grid1.RowsProportions.Add(new Grid.Proportion());
			grid1.RowsProportions.Add(new Grid.Proportion());
			grid1.Widgets.Add(textBlock1);
			grid1.Widgets.Add(_textPath);
			grid1.Widgets.Add(_buttonBrowse);
			grid1.Widgets.Add(textBlock2);
			grid1.Widgets.Add(_comboAnimations);

			_labelFps = new TextBlock();
			_labelFps.Text = "FPS: 60.0";
			_labelFps.Id = "_labelFps";

			_labelCamera = new TextBlock();
			_labelCamera.Text = "Camera: 0/50/0;270;0";
			_labelCamera.Id = "_labelCamera";
			_labelCamera.GridRow = 1;

			var grid2 = new Grid();
			grid2.ColumnsProportions.Add(new Grid.Proportion());
			grid2.ColumnsProportions.Add(new Grid.Proportion());
			grid2.RowsProportions.Add(new Grid.Proportion());
			grid2.RowsProportions.Add(new Grid.Proportion());
			grid2.RowsProportions.Add(new Grid.Proportion());
			grid2.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Right;
			grid2.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Bottom;
			grid2.Widgets.Add(_labelFps);
			grid2.Widgets.Add(_labelCamera);

			
			Widgets.Add(grid1);
			Widgets.Add(grid2);
		}

		
		public TextField _textPath;
		public TextButton _buttonBrowse;
		public ComboBox _comboAnimations;
		public TextBlock _labelFps;
		public TextBlock _labelCamera;
	}
}