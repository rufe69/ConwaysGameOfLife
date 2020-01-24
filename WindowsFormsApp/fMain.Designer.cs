using System.Drawing;

namespace WindowsFormsApp
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pStartMenu = new System.Windows.Forms.Panel();
            this.tbFieldLength = new System.Windows.Forms.TextBox();
            this.checkRandom = new System.Windows.Forms.CheckBox();
            this.btStartGame = new System.Windows.Forms.Button();
            this.pGameField = new System.Windows.Forms.Panel();
            this.pStartMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pStartMenu
            // 
            this.pStartMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pStartMenu.Controls.Add(this.tbFieldLength);
            this.pStartMenu.Controls.Add(this.checkRandom);
            this.pStartMenu.Controls.Add(this.btStartGame);
            this.pStartMenu.Location = new System.Drawing.Point(236, 180);
            this.pStartMenu.Name = "pStartMenu";
            this.pStartMenu.Size = new System.Drawing.Size(312, 201);
            this.pStartMenu.TabIndex = 0;
            // 
            // tbFieldLength
            // 
            this.tbFieldLength.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbFieldLength.Location = new System.Drawing.Point(79, 44);
            this.tbFieldLength.Name = "tbFieldLength";
            this.tbFieldLength.PlaceholderText = "Размер поля";
            this.tbFieldLength.Size = new System.Drawing.Size(151, 32);
            this.tbFieldLength.TabIndex = 2;
            this.tbFieldLength.Enter += new System.EventHandler(this.tbFieldLength_Enter);
            this.tbFieldLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFieldLength_KeyPress);
            // 
            // checkRandom
            // 
            this.checkRandom.AutoSize = true;
            this.checkRandom.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkRandom.Location = new System.Drawing.Point(79, 82);
            this.checkRandom.Name = "checkRandom";
            this.checkRandom.Size = new System.Drawing.Size(162, 20);
            this.checkRandom.TabIndex = 1;
            this.checkRandom.Text = "Случайная растановка";
            this.checkRandom.UseVisualStyleBackColor = true;
            // 
            // btStartGame
            // 
            this.btStartGame.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btStartGame.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStartGame.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btStartGame.Location = new System.Drawing.Point(64, 137);
            this.btStartGame.Name = "btStartGame";
            this.btStartGame.Size = new System.Drawing.Size(184, 43);
            this.btStartGame.TabIndex = 0;
            this.btStartGame.TabStop = false;
            this.btStartGame.Text = "Начать игру";
            this.btStartGame.UseVisualStyleBackColor = true;
            this.btStartGame.Click += new System.EventHandler(this.btCustomGame_Click);
            // 
            // pGameField
            // 
            this.pGameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGameField.Location = new System.Drawing.Point(0, 0);
            this.pGameField.Name = "pGameField";
            this.pGameField.Size = new System.Drawing.Size(784, 561);
            this.pGameField.TabIndex = 1;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pStartMenu);
            this.Controls.Add(this.pGameField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра в жизнь Джона Конвея";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fMain_KeyDown);
            this.pStartMenu.ResumeLayout(false);
            this.pStartMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btStartGame;
        private System.Windows.Forms.Panel pStartMenu;
        private System.Windows.Forms.CheckBox checkRandom;
        private System.Windows.Forms.TextBox tbFieldLength;
        private System.Windows.Forms.Panel pGameField;
    }
}