﻿namespace TriangularMesh
{
    partial class TriangularMesh
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.ToolsBox = new System.Windows.Forms.GroupBox();
            this.ImportFoxMapButton = new System.Windows.Forms.Button();
            this.ClearNormalMapButton = new System.Windows.Forms.Button();
            this.NormalMapButton = new System.Windows.Forms.Button();
            this.SurfaceImageButton = new System.Windows.Forms.Button();
            this.AnimationButton = new System.Windows.Forms.CheckBox();
            this.FlashlightBox = new System.Windows.Forms.GroupBox();
            this.LightSourceZBar = new System.Windows.Forms.TrackBar();
            this.LightSourceYBar = new System.Windows.Forms.TrackBar();
            this.LightSourceXBar = new System.Windows.Forms.TrackBar();
            this.SurfaceParametersBox = new System.Windows.Forms.GroupBox();
            this.SpecularMTrackBar = new System.Windows.Forms.TrackBar();
            this.SpecularTrackBar = new System.Windows.Forms.TrackBar();
            this.DispersedTrackBar = new System.Windows.Forms.TrackBar();
            this.z_ControlPointBar = new System.Windows.Forms.TrackBar();
            this.SurfaceColorButton = new System.Windows.Forms.Button();
            this.LightColorButton = new System.Windows.Forms.Button();
            this.ControlPointsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.MeshVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.y_IntervalCountBar = new System.Windows.Forms.TrackBar();
            this.x_IntervalCountBar = new System.Windows.Forms.TrackBar();
            this.LabToolBox = new System.Windows.Forms.GroupBox();
            this.TranslationGroupBox = new System.Windows.Forms.GroupBox();
            this.TranslateCheckBox = new System.Windows.Forms.CheckBox();
            this.BetaBar = new System.Windows.Forms.TrackBar();
            this.AlphaBar = new System.Windows.Forms.TrackBar();
            this.SpotlightCosineBar = new System.Windows.Forms.TrackBar();
            this.MainLightOutCheckBox = new System.Windows.Forms.CheckBox();
            this.SpotlightsOnButton = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.ToolsBox.SuspendLayout();
            this.FlashlightBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceZBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceYBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceXBar)).BeginInit();
            this.SurfaceParametersBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpecularMTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecularTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DispersedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_ControlPointBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_IntervalCountBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_IntervalCountBar)).BeginInit();
            this.LabToolBox.SuspendLayout();
            this.TranslationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BetaBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpotlightCosineBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(12, 12);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(657, 657);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseClick);
            // 
            // ToolsBox
            // 
            this.ToolsBox.Controls.Add(this.ImportFoxMapButton);
            this.ToolsBox.Controls.Add(this.ClearNormalMapButton);
            this.ToolsBox.Controls.Add(this.NormalMapButton);
            this.ToolsBox.Controls.Add(this.SurfaceImageButton);
            this.ToolsBox.Controls.Add(this.AnimationButton);
            this.ToolsBox.Controls.Add(this.FlashlightBox);
            this.ToolsBox.Controls.Add(this.SurfaceParametersBox);
            this.ToolsBox.Controls.Add(this.z_ControlPointBar);
            this.ToolsBox.Controls.Add(this.SurfaceColorButton);
            this.ToolsBox.Controls.Add(this.LightColorButton);
            this.ToolsBox.Controls.Add(this.ControlPointsVisibleCheckBox);
            this.ToolsBox.Controls.Add(this.MeshVisibleCheckBox);
            this.ToolsBox.Controls.Add(this.y_IntervalCountBar);
            this.ToolsBox.Controls.Add(this.x_IntervalCountBar);
            this.ToolsBox.Location = new System.Drawing.Point(675, 12);
            this.ToolsBox.Name = "ToolsBox";
            this.ToolsBox.Size = new System.Drawing.Size(202, 657);
            this.ToolsBox.TabIndex = 1;
            this.ToolsBox.TabStop = false;
            this.ToolsBox.Text = "Tools";
            // 
            // ImportFoxMapButton
            // 
            this.ImportFoxMapButton.Location = new System.Drawing.Point(149, 628);
            this.ImportFoxMapButton.Name = "ImportFoxMapButton";
            this.ImportFoxMapButton.Size = new System.Drawing.Size(41, 23);
            this.ImportFoxMapButton.TabIndex = 16;
            this.ImportFoxMapButton.Text = "Fox";
            this.ImportFoxMapButton.UseVisualStyleBackColor = true;
            this.ImportFoxMapButton.Click += new System.EventHandler(this.ImportFoxMapButton_Click);
            // 
            // ClearNormalMapButton
            // 
            this.ClearNormalMapButton.Location = new System.Drawing.Point(12, 628);
            this.ClearNormalMapButton.Name = "ClearNormalMapButton";
            this.ClearNormalMapButton.Size = new System.Drawing.Size(59, 23);
            this.ClearNormalMapButton.TabIndex = 15;
            this.ClearNormalMapButton.Text = "No map";
            this.ClearNormalMapButton.UseVisualStyleBackColor = true;
            this.ClearNormalMapButton.Click += new System.EventHandler(this.ClearNormalMapButton_Click);
            // 
            // NormalMapButton
            // 
            this.NormalMapButton.Location = new System.Drawing.Point(121, 576);
            this.NormalMapButton.Name = "NormalMapButton";
            this.NormalMapButton.Size = new System.Drawing.Size(75, 23);
            this.NormalMapButton.TabIndex = 14;
            this.NormalMapButton.Text = "NormMap";
            this.NormalMapButton.UseVisualStyleBackColor = true;
            this.NormalMapButton.Click += new System.EventHandler(this.NormalMapButton_Click);
            // 
            // SurfaceImageButton
            // 
            this.SurfaceImageButton.Location = new System.Drawing.Point(57, 576);
            this.SurfaceImageButton.Name = "SurfaceImageButton";
            this.SurfaceImageButton.Size = new System.Drawing.Size(58, 23);
            this.SurfaceImageButton.TabIndex = 13;
            this.SurfaceImageButton.Text = "Image";
            this.SurfaceImageButton.UseVisualStyleBackColor = true;
            this.SurfaceImageButton.Click += new System.EventHandler(this.SurfaceImageButton_Click);
            // 
            // AnimationButton
            // 
            this.AnimationButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.AnimationButton.AutoSize = true;
            this.AnimationButton.Location = new System.Drawing.Point(12, 575);
            this.AnimationButton.Name = "AnimationButton";
            this.AnimationButton.Size = new System.Drawing.Size(39, 25);
            this.AnimationButton.TabIndex = 12;
            this.AnimationButton.Text = "Play";
            this.AnimationButton.UseVisualStyleBackColor = true;
            this.AnimationButton.CheckedChanged += new System.EventHandler(this.AnimationButton_CheckedChanged);
            // 
            // FlashlightBox
            // 
            this.FlashlightBox.Controls.Add(this.LightSourceZBar);
            this.FlashlightBox.Controls.Add(this.LightSourceYBar);
            this.FlashlightBox.Controls.Add(this.LightSourceXBar);
            this.FlashlightBox.Location = new System.Drawing.Point(6, 387);
            this.FlashlightBox.Name = "FlashlightBox";
            this.FlashlightBox.Size = new System.Drawing.Size(190, 178);
            this.FlashlightBox.TabIndex = 11;
            this.FlashlightBox.TabStop = false;
            this.FlashlightBox.Text = "Flashlight position";
            // 
            // LightSourceZBar
            // 
            this.LightSourceZBar.Location = new System.Drawing.Point(6, 124);
            this.LightSourceZBar.Maximum = 400;
            this.LightSourceZBar.Minimum = 1;
            this.LightSourceZBar.Name = "LightSourceZBar";
            this.LightSourceZBar.Size = new System.Drawing.Size(178, 45);
            this.LightSourceZBar.TabIndex = 2;
            this.LightSourceZBar.TickFrequency = 0;
            this.LightSourceZBar.Value = 100;
            this.LightSourceZBar.ValueChanged += new System.EventHandler(this.LightSourceZBar_ValueChanged);
            // 
            // LightSourceYBar
            // 
            this.LightSourceYBar.Location = new System.Drawing.Point(6, 73);
            this.LightSourceYBar.Maximum = 100;
            this.LightSourceYBar.Name = "LightSourceYBar";
            this.LightSourceYBar.Size = new System.Drawing.Size(178, 45);
            this.LightSourceYBar.TabIndex = 1;
            this.LightSourceYBar.TickFrequency = 0;
            this.LightSourceYBar.Value = 50;
            this.LightSourceYBar.ValueChanged += new System.EventHandler(this.LightSourceYBar_ValueChanged);
            // 
            // LightSourceXBar
            // 
            this.LightSourceXBar.Location = new System.Drawing.Point(6, 22);
            this.LightSourceXBar.Maximum = 100;
            this.LightSourceXBar.Name = "LightSourceXBar";
            this.LightSourceXBar.Size = new System.Drawing.Size(178, 45);
            this.LightSourceXBar.TabIndex = 0;
            this.LightSourceXBar.TickFrequency = 0;
            this.LightSourceXBar.Value = 50;
            this.LightSourceXBar.ValueChanged += new System.EventHandler(this.LightSourceXBar_ValueChanged);
            // 
            // SurfaceParametersBox
            // 
            this.SurfaceParametersBox.Controls.Add(this.SpecularMTrackBar);
            this.SurfaceParametersBox.Controls.Add(this.SpecularTrackBar);
            this.SurfaceParametersBox.Controls.Add(this.DispersedTrackBar);
            this.SurfaceParametersBox.Location = new System.Drawing.Point(6, 203);
            this.SurfaceParametersBox.Name = "SurfaceParametersBox";
            this.SurfaceParametersBox.Size = new System.Drawing.Size(190, 178);
            this.SurfaceParametersBox.TabIndex = 10;
            this.SurfaceParametersBox.TabStop = false;
            this.SurfaceParametersBox.Text = "Surface parameters";
            // 
            // SpecularMTrackBar
            // 
            this.SpecularMTrackBar.Location = new System.Drawing.Point(6, 124);
            this.SpecularMTrackBar.Maximum = 100;
            this.SpecularMTrackBar.Minimum = 1;
            this.SpecularMTrackBar.Name = "SpecularMTrackBar";
            this.SpecularMTrackBar.Size = new System.Drawing.Size(179, 45);
            this.SpecularMTrackBar.TabIndex = 8;
            this.SpecularMTrackBar.TickFrequency = 0;
            this.SpecularMTrackBar.Value = 50;
            this.SpecularMTrackBar.ValueChanged += new System.EventHandler(this.SpecularMTrackBar_ValueChanged);
            // 
            // SpecularTrackBar
            // 
            this.SpecularTrackBar.Location = new System.Drawing.Point(6, 73);
            this.SpecularTrackBar.Maximum = 100;
            this.SpecularTrackBar.Name = "SpecularTrackBar";
            this.SpecularTrackBar.Size = new System.Drawing.Size(179, 45);
            this.SpecularTrackBar.TabIndex = 7;
            this.SpecularTrackBar.TickFrequency = 0;
            this.SpecularTrackBar.Value = 50;
            this.SpecularTrackBar.ValueChanged += new System.EventHandler(this.SpecularTrackBar_ValueChanged);
            // 
            // DispersedTrackBar
            // 
            this.DispersedTrackBar.Location = new System.Drawing.Point(6, 22);
            this.DispersedTrackBar.Maximum = 100;
            this.DispersedTrackBar.Name = "DispersedTrackBar";
            this.DispersedTrackBar.Size = new System.Drawing.Size(179, 45);
            this.DispersedTrackBar.TabIndex = 6;
            this.DispersedTrackBar.TickFrequency = 0;
            this.DispersedTrackBar.Value = 50;
            this.DispersedTrackBar.ValueChanged += new System.EventHandler(this.DispersedTrackBar_ValueChanged);
            // 
            // z_ControlPointBar
            // 
            this.z_ControlPointBar.Enabled = false;
            this.z_ControlPointBar.Location = new System.Drawing.Point(11, 606);
            this.z_ControlPointBar.Maximum = 300;
            this.z_ControlPointBar.Minimum = -300;
            this.z_ControlPointBar.Name = "z_ControlPointBar";
            this.z_ControlPointBar.Size = new System.Drawing.Size(179, 45);
            this.z_ControlPointBar.TabIndex = 9;
            this.z_ControlPointBar.TickFrequency = 0;
            this.z_ControlPointBar.ValueChanged += new System.EventHandler(this.z_ControlPointBar_ValueChanged);
            // 
            // SurfaceColorButton
            // 
            this.SurfaceColorButton.Location = new System.Drawing.Point(102, 174);
            this.SurfaceColorButton.Name = "SurfaceColorButton";
            this.SurfaceColorButton.Size = new System.Drawing.Size(89, 23);
            this.SurfaceColorButton.TabIndex = 5;
            this.SurfaceColorButton.Text = "Surface color";
            this.SurfaceColorButton.UseVisualStyleBackColor = true;
            this.SurfaceColorButton.Click += new System.EventHandler(this.SurfaceColorButton_Click);
            // 
            // LightColorButton
            // 
            this.LightColorButton.Location = new System.Drawing.Point(12, 174);
            this.LightColorButton.Name = "LightColorButton";
            this.LightColorButton.Size = new System.Drawing.Size(84, 23);
            this.LightColorButton.TabIndex = 4;
            this.LightColorButton.Text = "Light color";
            this.LightColorButton.UseVisualStyleBackColor = true;
            this.LightColorButton.Click += new System.EventHandler(this.LightColorButton_Click);
            // 
            // ControlPointsVisibleCheckBox
            // 
            this.ControlPointsVisibleCheckBox.AutoSize = true;
            this.ControlPointsVisibleCheckBox.Location = new System.Drawing.Point(12, 149);
            this.ControlPointsVisibleCheckBox.Name = "ControlPointsVisibleCheckBox";
            this.ControlPointsVisibleCheckBox.Size = new System.Drawing.Size(138, 19);
            this.ControlPointsVisibleCheckBox.TabIndex = 3;
            this.ControlPointsVisibleCheckBox.Text = "Control points visible";
            this.ControlPointsVisibleCheckBox.UseVisualStyleBackColor = true;
            this.ControlPointsVisibleCheckBox.CheckedChanged += new System.EventHandler(this.ControlPointsVisibleCheckBox_CheckedChanged);
            // 
            // MeshVisibleCheckBox
            // 
            this.MeshVisibleCheckBox.AutoSize = true;
            this.MeshVisibleCheckBox.Location = new System.Drawing.Point(12, 124);
            this.MeshVisibleCheckBox.Name = "MeshVisibleCheckBox";
            this.MeshVisibleCheckBox.Size = new System.Drawing.Size(91, 19);
            this.MeshVisibleCheckBox.TabIndex = 2;
            this.MeshVisibleCheckBox.Text = "Mesh visible";
            this.MeshVisibleCheckBox.UseVisualStyleBackColor = true;
            this.MeshVisibleCheckBox.CheckedChanged += new System.EventHandler(this.MeshVisibleCheckBox_CheckedChanged);
            // 
            // y_IntervalCountBar
            // 
            this.y_IntervalCountBar.Location = new System.Drawing.Point(12, 73);
            this.y_IntervalCountBar.Maximum = 30;
            this.y_IntervalCountBar.Minimum = 3;
            this.y_IntervalCountBar.Name = "y_IntervalCountBar";
            this.y_IntervalCountBar.Size = new System.Drawing.Size(179, 45);
            this.y_IntervalCountBar.TabIndex = 1;
            this.y_IntervalCountBar.Value = 30;
            this.y_IntervalCountBar.ValueChanged += new System.EventHandler(this.y_IntervalCountBar_ValueChanged);
            // 
            // x_IntervalCountBar
            // 
            this.x_IntervalCountBar.Location = new System.Drawing.Point(12, 22);
            this.x_IntervalCountBar.Maximum = 30;
            this.x_IntervalCountBar.Minimum = 3;
            this.x_IntervalCountBar.Name = "x_IntervalCountBar";
            this.x_IntervalCountBar.Size = new System.Drawing.Size(179, 45);
            this.x_IntervalCountBar.TabIndex = 0;
            this.x_IntervalCountBar.Value = 30;
            this.x_IntervalCountBar.ValueChanged += new System.EventHandler(this.x_IntervalCountBar_ValueChanged);
            // 
            // LabToolBox
            // 
            this.LabToolBox.Controls.Add(this.TranslationGroupBox);
            this.LabToolBox.Controls.Add(this.SpotlightCosineBar);
            this.LabToolBox.Controls.Add(this.MainLightOutCheckBox);
            this.LabToolBox.Controls.Add(this.SpotlightsOnButton);
            this.LabToolBox.Location = new System.Drawing.Point(883, 12);
            this.LabToolBox.Name = "LabToolBox";
            this.LabToolBox.Size = new System.Drawing.Size(161, 657);
            this.LabToolBox.TabIndex = 2;
            this.LabToolBox.TabStop = false;
            this.LabToolBox.Text = "Labs";
            // 
            // TranslationGroupBox
            // 
            this.TranslationGroupBox.Controls.Add(this.TranslateCheckBox);
            this.TranslationGroupBox.Controls.Add(this.BetaBar);
            this.TranslationGroupBox.Controls.Add(this.AlphaBar);
            this.TranslationGroupBox.Location = new System.Drawing.Point(6, 106);
            this.TranslationGroupBox.Name = "TranslationGroupBox";
            this.TranslationGroupBox.Size = new System.Drawing.Size(149, 149);
            this.TranslationGroupBox.TabIndex = 3;
            this.TranslationGroupBox.TabStop = false;
            this.TranslationGroupBox.Text = "Translation";
            // 
            // TranslateCheckBox
            // 
            this.TranslateCheckBox.AutoSize = true;
            this.TranslateCheckBox.Location = new System.Drawing.Point(11, 119);
            this.TranslateCheckBox.Name = "TranslateCheckBox";
            this.TranslateCheckBox.Size = new System.Drawing.Size(72, 19);
            this.TranslateCheckBox.TabIndex = 2;
            this.TranslateCheckBox.Text = "Translate";
            this.TranslateCheckBox.UseVisualStyleBackColor = true;
            this.TranslateCheckBox.CheckedChanged += new System.EventHandler(this.TranslateCheckBox_CheckedChanged);
            // 
            // BetaBar
            // 
            this.BetaBar.Location = new System.Drawing.Point(6, 68);
            this.BetaBar.Name = "BetaBar";
            this.BetaBar.Size = new System.Drawing.Size(133, 45);
            this.BetaBar.TabIndex = 1;
            this.BetaBar.ValueChanged += new System.EventHandler(this.BetaBar_ValueChanged);
            // 
            // AlphaBar
            // 
            this.AlphaBar.Location = new System.Drawing.Point(6, 22);
            this.AlphaBar.Name = "AlphaBar";
            this.AlphaBar.Size = new System.Drawing.Size(133, 45);
            this.AlphaBar.TabIndex = 0;
            this.AlphaBar.ValueChanged += new System.EventHandler(this.AlphaBar_ValueChanged);
            // 
            // SpotlightCosineBar
            // 
            this.SpotlightCosineBar.Location = new System.Drawing.Point(14, 73);
            this.SpotlightCosineBar.Maximum = 100;
            this.SpotlightCosineBar.Minimum = 1;
            this.SpotlightCosineBar.Name = "SpotlightCosineBar";
            this.SpotlightCosineBar.Size = new System.Drawing.Size(131, 45);
            this.SpotlightCosineBar.TabIndex = 2;
            this.SpotlightCosineBar.TickFrequency = 0;
            this.SpotlightCosineBar.Value = 100;
            this.SpotlightCosineBar.ValueChanged += new System.EventHandler(this.SpotlightCosineBar_ValueChanged);
            // 
            // MainLightOutCheckBox
            // 
            this.MainLightOutCheckBox.AutoSize = true;
            this.MainLightOutCheckBox.Location = new System.Drawing.Point(17, 48);
            this.MainLightOutCheckBox.Name = "MainLightOutCheckBox";
            this.MainLightOutCheckBox.Size = new System.Drawing.Size(101, 19);
            this.MainLightOutCheckBox.TabIndex = 1;
            this.MainLightOutCheckBox.Text = "Main light out";
            this.MainLightOutCheckBox.UseVisualStyleBackColor = true;
            this.MainLightOutCheckBox.CheckedChanged += new System.EventHandler(this.MainLightOutCheckBox_CheckedChanged);
            // 
            // SpotlightsOnButton
            // 
            this.SpotlightsOnButton.AutoSize = true;
            this.SpotlightsOnButton.Location = new System.Drawing.Point(17, 22);
            this.SpotlightsOnButton.Name = "SpotlightsOnButton";
            this.SpotlightsOnButton.Size = new System.Drawing.Size(96, 19);
            this.SpotlightsOnButton.TabIndex = 0;
            this.SpotlightsOnButton.Text = "Spotlights on";
            this.SpotlightsOnButton.UseVisualStyleBackColor = true;
            this.SpotlightsOnButton.Click += new System.EventHandler(this.SpotlightsOnButton_Click);
            // 
            // TriangularMesh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 681);
            this.Controls.Add(this.LabToolBox);
            this.Controls.Add(this.ToolsBox);
            this.Controls.Add(this.Canvas);
            this.MaximumSize = new System.Drawing.Size(1072, 720);
            this.MinimumSize = new System.Drawing.Size(900, 720);
            this.Name = "TriangularMesh";
            this.Text = "TriangularMesh";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ToolsBox.ResumeLayout(false);
            this.ToolsBox.PerformLayout();
            this.FlashlightBox.ResumeLayout(false);
            this.FlashlightBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceZBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceYBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceXBar)).EndInit();
            this.SurfaceParametersBox.ResumeLayout(false);
            this.SurfaceParametersBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpecularMTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecularTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DispersedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z_ControlPointBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.y_IntervalCountBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_IntervalCountBar)).EndInit();
            this.LabToolBox.ResumeLayout(false);
            this.LabToolBox.PerformLayout();
            this.TranslationGroupBox.ResumeLayout(false);
            this.TranslationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BetaBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpotlightCosineBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox Canvas;
        private GroupBox ToolsBox;
        private TrackBar x_IntervalCountBar;
        private TrackBar y_IntervalCountBar;
        private CheckBox MeshVisibleCheckBox;
        private CheckBox ControlPointsVisibleCheckBox;
        private Button SurfaceColorButton;
        private Button LightColorButton;
        private TrackBar SpecularMTrackBar;
        private TrackBar SpecularTrackBar;
        private TrackBar DispersedTrackBar;
        private TrackBar z_ControlPointBar;
        private GroupBox SurfaceParametersBox;
        private GroupBox FlashlightBox;
        private TrackBar LightSourceYBar;
        private TrackBar LightSourceXBar;
        private CheckBox AnimationButton;
        private TrackBar LightSourceZBar;
        private Button SurfaceImageButton;
        private Button NormalMapButton;
        private Button ClearNormalMapButton;
        private Button ImportFoxMapButton;
        private GroupBox LabToolBox;
        private CheckBox SpotlightsOnButton;
        private CheckBox MainLightOutCheckBox;
        private TrackBar SpotlightCosineBar;
        private GroupBox TranslationGroupBox;
        private CheckBox TranslateCheckBox;
        private TrackBar BetaBar;
        private TrackBar AlphaBar;
    }
}