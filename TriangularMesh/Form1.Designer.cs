namespace TriangularMesh
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
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.ControlPointsVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.MeshVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.y_IntervalCountBar = new System.Windows.Forms.TrackBar();
            this.x_IntervalCountBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.y_IntervalCountBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_IntervalCountBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(12, 12);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(657, 657);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.ControlPointsVisibleCheckBox);
            this.GroupBox.Controls.Add(this.MeshVisibleCheckBox);
            this.GroupBox.Controls.Add(this.y_IntervalCountBar);
            this.GroupBox.Controls.Add(this.x_IntervalCountBar);
            this.GroupBox.Location = new System.Drawing.Point(675, 12);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(176, 657);
            this.GroupBox.TabIndex = 1;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Tools";
            // 
            // ControlPointsVisibleCheckBox
            // 
            this.ControlPointsVisibleCheckBox.AutoSize = true;
            this.ControlPointsVisibleCheckBox.Checked = true;
            this.ControlPointsVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ControlPointsVisibleCheckBox.Location = new System.Drawing.Point(6, 149);
            this.ControlPointsVisibleCheckBox.Name = "ControlPointsVisibleCheckBox";
            this.ControlPointsVisibleCheckBox.Size = new System.Drawing.Size(138, 19);
            this.ControlPointsVisibleCheckBox.TabIndex = 3;
            this.ControlPointsVisibleCheckBox.Text = "Control points visible";
            this.ControlPointsVisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // MeshVisibleCheckBox
            // 
            this.MeshVisibleCheckBox.AutoSize = true;
            this.MeshVisibleCheckBox.Checked = true;
            this.MeshVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MeshVisibleCheckBox.Location = new System.Drawing.Point(6, 124);
            this.MeshVisibleCheckBox.Name = "MeshVisibleCheckBox";
            this.MeshVisibleCheckBox.Size = new System.Drawing.Size(91, 19);
            this.MeshVisibleCheckBox.TabIndex = 2;
            this.MeshVisibleCheckBox.Text = "Mesh visible";
            this.MeshVisibleCheckBox.UseVisualStyleBackColor = true;
            this.MeshVisibleCheckBox.CheckedChanged += new System.EventHandler(this.MeshVisibleCheckBox_CheckedChanged);
            // 
            // y_IntervalCountBar
            // 
            this.y_IntervalCountBar.Location = new System.Drawing.Point(6, 73);
            this.y_IntervalCountBar.Maximum = 30;
            this.y_IntervalCountBar.Minimum = 1;
            this.y_IntervalCountBar.Name = "y_IntervalCountBar";
            this.y_IntervalCountBar.Size = new System.Drawing.Size(164, 45);
            this.y_IntervalCountBar.TabIndex = 1;
            this.y_IntervalCountBar.Value = 1;
            // 
            // x_IntervalCountBar
            // 
            this.x_IntervalCountBar.Location = new System.Drawing.Point(6, 22);
            this.x_IntervalCountBar.Maximum = 30;
            this.x_IntervalCountBar.Minimum = 1;
            this.x_IntervalCountBar.Name = "x_IntervalCountBar";
            this.x_IntervalCountBar.Size = new System.Drawing.Size(164, 45);
            this.x_IntervalCountBar.TabIndex = 0;
            this.x_IntervalCountBar.Value = 1;
            // 
            // TriangularMesh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 681);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.Canvas);
            this.Name = "TriangularMesh";
            this.Text = "TriangularMesh";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.y_IntervalCountBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.x_IntervalCountBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox Canvas;
        private GroupBox GroupBox;
        private TrackBar x_IntervalCountBar;
        private TrackBar y_IntervalCountBar;
        private CheckBox MeshVisibleCheckBox;
        private CheckBox ControlPointsVisibleCheckBox;
    }
}