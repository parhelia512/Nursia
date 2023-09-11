/* Generated by MyraPad at 9/11/2023 9:24:08 PM */
using Myra;
using Myra.Graphics2D;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI.Properties;
using FontStashSharp.RichText;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nursia.Samples.LevelEditor.UI
{
	partial class MainForm: VerticalStackPanel
	{
		private void BuildUI()
		{
			_menuItemQuit = new MenuItem();
			_menuItemQuit.Text = "&Quit";
			_menuItemQuit.Id = "_menuItemQuit";

			var menuItem1 = new MenuItem();
			menuItem1.Text = "&File";
			menuItem1.Items.Add(_menuItemQuit);

			_menuItemAddModel = new MenuItem();
			_menuItemAddModel.Text = "&Model";
			_menuItemAddModel.Id = "_menuItemAddModel";

			_menuItemAddSkybox = new MenuItem();
			_menuItemAddSkybox.Text = "&Skybox";
			_menuItemAddSkybox.Id = "_menuItemAddSkybox";

			_menuItemAddTerrain = new MenuItem();
			_menuItemAddTerrain.Text = "&Terrain";
			_menuItemAddTerrain.Id = "_menuItemAddTerrain";

			_menuItemAddWater = new MenuItem();
			_menuItemAddWater.Text = "&Water";
			_menuItemAddWater.Id = "_menuItemAddWater";

			var menuItem2 = new MenuItem();
			menuItem2.Text = "&Items";
			menuItem2.Items.Add(_menuItemAddModel);
			menuItem2.Items.Add(_menuItemAddSkybox);
			menuItem2.Items.Add(_menuItemAddTerrain);
			menuItem2.Items.Add(_menuItemAddWater);

			_menuItemShowGrid = new MenuItem();
			_menuItemShowGrid.Text = "&Grid";
			_menuItemShowGrid.Id = "_menuItemShowGrid";

			_menuItemLockFps = new MenuItem();
			_menuItemLockFps.Text = "&Lock FPS at 60";
			_menuItemLockFps.Id = "_menuItemLockFps";

			var menuItem3 = new MenuItem();
			menuItem3.Text = "&Options";
			menuItem3.Items.Add(_menuItemShowGrid);
			menuItem3.Items.Add(_menuItemLockFps);

			_menuItemAbout = new MenuItem();
			_menuItemAbout.Text = "&About";
			_menuItemAbout.Id = "_menuItemAbout";

			var menuItem4 = new MenuItem();
			menuItem4.Text = "&Help";
			menuItem4.Items.Add(_menuItemAbout);

			var horizontalMenu1 = new HorizontalMenu();
			horizontalMenu1.Items.Add(menuItem1);
			horizontalMenu1.Items.Add(menuItem2);
			horizontalMenu1.Items.Add(menuItem3);
			horizontalMenu1.Items.Add(menuItem4);

			var textButton1 = new TextButton();
			textButton1.Text = "Raise";
			textButton1.Toggleable = true;
			textButton1.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Stretch;
			textButton1.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Stretch;

			var textButton2 = new TextButton();
			textButton2.Text = "Lower";
			textButton2.Toggleable = true;
			textButton2.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Stretch;
			textButton2.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Stretch;
			textButton2.GridColumn = 1;

			_gridTerrainLibrary = new Grid();
			_gridTerrainLibrary.ColumnSpacing = 8;
			_gridTerrainLibrary.RowSpacing = 8;
			_gridTerrainLibrary.DefaultRowProportion = new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			};
			_gridTerrainLibrary.ColumnsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Part,
			});
			_gridTerrainLibrary.ColumnsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Part,
			});
			_gridTerrainLibrary.ColumnsProportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Part,
			});
			_gridTerrainLibrary.Id = "_gridTerrainLibrary";
			_gridTerrainLibrary.Widgets.Add(textButton1);
			_gridTerrainLibrary.Widgets.Add(textButton2);

			_labelTerrainRadius = new Label();
			_labelTerrainRadius.Text = "Radius: 5.0";
			_labelTerrainRadius.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;
			_labelTerrainRadius.Id = "_labelTerrainRadius";

			_sliderTerrainRadius = new HorizontalSlider();
			_sliderTerrainRadius.Minimum = 1;
			_sliderTerrainRadius.Maximum = 10;
			_sliderTerrainRadius.Value = 3.2536585f;
			_sliderTerrainRadius.Id = "_sliderTerrainRadius";

			_labelTerrainPower = new Label();
			_labelTerrainPower.Text = "Power: 0.5";
			_labelTerrainPower.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Center;
			_labelTerrainPower.Id = "_labelTerrainPower";

			_sliderTerrainPower = new HorizontalSlider();
			_sliderTerrainPower.Maximum = 1;
			_sliderTerrainPower.Value = 0.4276423f;
			_sliderTerrainPower.Id = "_sliderTerrainPower";

			var verticalStackPanel1 = new VerticalStackPanel();
			verticalStackPanel1.Spacing = 4;
			verticalStackPanel1.Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Fill,
			});
			verticalStackPanel1.Widgets.Add(_gridTerrainLibrary);
			verticalStackPanel1.Widgets.Add(_labelTerrainRadius);
			verticalStackPanel1.Widgets.Add(_sliderTerrainRadius);
			verticalStackPanel1.Widgets.Add(_labelTerrainPower);
			verticalStackPanel1.Widgets.Add(_sliderTerrainPower);

			var tabItem1 = new TabItem();
			tabItem1.Text = "Terrain";
			tabItem1.ContentVerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Stretch;
			tabItem1.Height = null;
			tabItem1.Content = verticalStackPanel1;

			var tabControl1 = new TabControl();
			tabControl1.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Stretch;
			tabControl1.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Stretch;
			tabControl1.Items.Add(tabItem1);

			_labelFps = new Label();
			_labelFps.Text = "FPS: 60.0";
			_labelFps.Id = "_labelFps";

			_labelMeshes = new Label();
			_labelMeshes.Text = "Meshes: 15";
			_labelMeshes.Id = "_labelMeshes";

			_labelCamera = new Label();
			_labelCamera.Text = "Camera: 0/50/0;270;0";
			_labelCamera.Id = "_labelCamera";

			var verticalStackPanel2 = new VerticalStackPanel();
			verticalStackPanel2.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Right;
			verticalStackPanel2.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Bottom;
			verticalStackPanel2.Widgets.Add(_labelFps);
			verticalStackPanel2.Widgets.Add(_labelMeshes);
			verticalStackPanel2.Widgets.Add(_labelCamera);

			_panelScene = new Panel();
			_panelScene.Id = "_panelScene";
			_panelScene.Widgets.Add(verticalStackPanel2);

			var listItem1 = new ListItem();
			listItem1.Text = "Directional Light (#_sun)";

			var listItem2 = new ListItem();
			listItem2.Text = "Camera (#_mainCamera)";

			var listItem3 = new ListItem();
			listItem3.Text = "Terrain (#_terrain)";

			var listItem4 = new ListItem();
			listItem4.Text = "Water (#_water)";

			_listExplorer = new ListBox();
			_listExplorer.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Stretch;
			_listExplorer.Id = "_listExplorer";
			_listExplorer.Items.Add(listItem1);
			_listExplorer.Items.Add(listItem2);
			_listExplorer.Items.Add(listItem3);
			_listExplorer.Items.Add(listItem4);

			_panelProperties = new Panel();
			_panelProperties.Id = "_panelProperties";

			var verticalSplitPane1 = new VerticalSplitPane();
			verticalSplitPane1.Widgets.Add(_listExplorer);
			verticalSplitPane1.Widgets.Add(_panelProperties);

			_topSplitPane = new HorizontalSplitPane();
			_topSplitPane.Id = "_topSplitPane";
			_topSplitPane.Widgets.Add(tabControl1);
			_topSplitPane.Widgets.Add(_panelScene);
			_topSplitPane.Widgets.Add(verticalSplitPane1);

			var panel1 = new Panel();
			panel1.Widgets.Add(_topSplitPane);

			
			Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Auto,
			});
			Proportions.Add(new Proportion
			{
				Type = Myra.Graphics2D.UI.ProportionType.Fill,
			});
			Widgets.Add(horizontalMenu1);
			Widgets.Add(panel1);
		}

		
		public MenuItem _menuItemQuit;
		public MenuItem _menuItemAddModel;
		public MenuItem _menuItemAddSkybox;
		public MenuItem _menuItemAddTerrain;
		public MenuItem _menuItemAddWater;
		public MenuItem _menuItemShowGrid;
		public MenuItem _menuItemLockFps;
		public MenuItem _menuItemAbout;
		public Grid _gridTerrainLibrary;
		public Label _labelTerrainRadius;
		public HorizontalSlider _sliderTerrainRadius;
		public Label _labelTerrainPower;
		public HorizontalSlider _sliderTerrainPower;
		public Label _labelFps;
		public Label _labelMeshes;
		public Label _labelCamera;
		public Panel _panelScene;
		public ListBox _listExplorer;
		public Panel _panelProperties;
		public HorizontalSplitPane _topSplitPane;
	}
}
