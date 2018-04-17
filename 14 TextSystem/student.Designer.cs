namespace _14_TextSystem
{
    partial class student
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.考试管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.练习模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.正式考试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账号管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.成绩查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联系我们ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.考试管理ToolStripMenuItem,
            this.账号管理ToolStripMenuItem,
            this.联系我们ToolStripMenuItem1,
            this.退出登录ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(350, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 考试管理ToolStripMenuItem
            // 
            this.考试管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.练习模式ToolStripMenuItem,
            this.正式考试ToolStripMenuItem});
            this.考试管理ToolStripMenuItem.Name = "考试管理ToolStripMenuItem";
            this.考试管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.考试管理ToolStripMenuItem.Text = "考试管理";
            // 
            // 练习模式ToolStripMenuItem
            // 
            this.练习模式ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.练习模式ToolStripMenuItem.Name = "练习模式ToolStripMenuItem";
            this.练习模式ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.练习模式ToolStripMenuItem.Text = "练习模式";
            this.练习模式ToolStripMenuItem.Click += new System.EventHandler(this.联系模式ToolStripMenuItem_Click);
            // 
            // 正式考试ToolStripMenuItem
            // 
            this.正式考试ToolStripMenuItem.Name = "正式考试ToolStripMenuItem";
            this.正式考试ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.正式考试ToolStripMenuItem.Text = "正式考试";
            this.正式考试ToolStripMenuItem.Click += new System.EventHandler(this.正式考试ToolStripMenuItem_Click);
            // 
            // 账号管理ToolStripMenuItem
            // 
            this.账号管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.成绩查询ToolStripMenuItem,
            this.修改密码ToolStripMenuItem});
            this.账号管理ToolStripMenuItem.Name = "账号管理ToolStripMenuItem";
            this.账号管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.账号管理ToolStripMenuItem.Text = "账号管理";
            // 
            // 成绩查询ToolStripMenuItem
            // 
            this.成绩查询ToolStripMenuItem.Name = "成绩查询ToolStripMenuItem";
            this.成绩查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.成绩查询ToolStripMenuItem.Text = "成绩查询";
            this.成绩查询ToolStripMenuItem.Click += new System.EventHandler(this.成绩查询ToolStripMenuItem_Click);
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // 联系我们ToolStripMenuItem1
            // 
            this.联系我们ToolStripMenuItem1.Name = "联系我们ToolStripMenuItem1";
            this.联系我们ToolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.联系我们ToolStripMenuItem1.Text = "联系我们";
            // 
            // 退出登录ToolStripMenuItem
            // 
            this.退出登录ToolStripMenuItem.Name = "退出登录ToolStripMenuItem";
            this.退出登录ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.退出登录ToolStripMenuItem.Text = "退出登录";
            this.退出登录ToolStripMenuItem.Click += new System.EventHandler(this.退出登录ToolStripMenuItem_Click_1);
            // 
            // student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 288);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "student";
            this.Text = "考试管理系统学生端";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 考试管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 练习模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 正式考试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 账号管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 成绩查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联系我们ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出登录ToolStripMenuItem;


    }
}