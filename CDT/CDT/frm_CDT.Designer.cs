namespace CDT
{
    partial class frm_CDT
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.prg_1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_log_rec = new System.Windows.Forms.GroupBox();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbc = new System.Windows.Forms.TabControl();
            this.tbc_p_welcome = new System.Windows.Forms.TabPage();
            this.txt_welcome = new System.Windows.Forms.TextBox();
            this.tbc_p_needs = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_min_gpu_tflops_sp = new System.Windows.Forms.TextBox();
            this.txt_min_gpu_tflops_dp = new System.Windows.Forms.TextBox();
            this.txt_min_ram = new System.Windows.Forms.TextBox();
            this.txt_min_vram = new System.Windows.Forms.TextBox();
            this.txt_min_cpu_gflops = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_ram_per_core = new System.Windows.Forms.TextBox();
            this.tbc_p_extrainfo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_total_budget = new System.Windows.Forms.TextBox();
            this.txt_monthly_power_budget = new System.Windows.Forms.TextBox();
            this.txt_max_power_delivery = new System.Windows.Forms.TextBox();
            this.txt_max_rack_power = new System.Windows.Forms.TextBox();
            this.txt_max_racks = new System.Windows.Forms.TextBox();
            this.tbc_p_recommendation = new System.Windows.Forms.TabPage();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_construction_cost = new System.Windows.Forms.TextBox();
            this.cmb_average_load_percent = new System.Windows.Forms.ComboBox();
            this.txt_daily_load_hours = new System.Windows.Forms.TextBox();
            this.txt_weekly_load_days = new System.Windows.Forms.TextBox();
            this.txt_electricity_cost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sampleInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lotsOfResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gb_log_rec.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbc.SuspendLayout();
            this.tbc_p_welcome.SuspendLayout();
            this.tbc_p_needs.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbc_p_extrainfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tbc_p_recommendation.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prg_1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 647);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1277, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // prg_1
            // 
            this.prg_1.Name = "prg_1";
            this.prg_1.Size = new System.Drawing.Size(250, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1277, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveOutputToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleInputToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // gb_log_rec
            // 
            this.gb_log_rec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_log_rec.Controls.Add(this.txt_log);
            this.gb_log_rec.Location = new System.Drawing.Point(575, 27);
            this.gb_log_rec.Name = "gb_log_rec";
            this.gb_log_rec.Size = new System.Drawing.Size(690, 612);
            this.gb_log_rec.TabIndex = 5;
            this.gb_log_rec.TabStop = false;
            this.gb_log_rec.Text = "Log";
            // 
            // txt_log
            // 
            this.txt_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_log.Location = new System.Drawing.Point(6, 25);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(678, 581);
            this.txt_log.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.tbc);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 606);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cluster Design Tool";
            // 
            // tbc
            // 
            this.tbc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbc.Controls.Add(this.tbc_p_welcome);
            this.tbc.Controls.Add(this.tbc_p_needs);
            this.tbc.Controls.Add(this.tbc_p_extrainfo);
            this.tbc.Controls.Add(this.tbc_p_recommendation);
            this.tbc.Location = new System.Drawing.Point(6, 25);
            this.tbc.Multiline = true;
            this.tbc.Name = "tbc";
            this.tbc.SelectedIndex = 0;
            this.tbc.Size = new System.Drawing.Size(551, 575);
            this.tbc.TabIndex = 4;
            // 
            // tbc_p_welcome
            // 
            this.tbc_p_welcome.Controls.Add(this.txt_welcome);
            this.tbc_p_welcome.Location = new System.Drawing.Point(4, 29);
            this.tbc_p_welcome.Name = "tbc_p_welcome";
            this.tbc_p_welcome.Padding = new System.Windows.Forms.Padding(3);
            this.tbc_p_welcome.Size = new System.Drawing.Size(543, 542);
            this.tbc_p_welcome.TabIndex = 0;
            this.tbc_p_welcome.Text = "Welcome";
            this.tbc_p_welcome.UseVisualStyleBackColor = true;
            // 
            // txt_welcome
            // 
            this.txt_welcome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_welcome.Location = new System.Drawing.Point(6, 6);
            this.txt_welcome.Multiline = true;
            this.txt_welcome.Name = "txt_welcome";
            this.txt_welcome.Size = new System.Drawing.Size(531, 530);
            this.txt_welcome.TabIndex = 2;
            this.txt_welcome.Text = "Welcome to the Cluster Design Tool. This simple tool will help guide the creation" +
    " of a cluster system that meets your needs, taking into account your available b" +
    "udget, power and space constraints.";
            // 
            // tbc_p_needs
            // 
            this.tbc_p_needs.Controls.Add(this.tableLayoutPanel1);
            this.tbc_p_needs.Location = new System.Drawing.Point(4, 29);
            this.tbc_p_needs.Name = "tbc_p_needs";
            this.tbc_p_needs.Padding = new System.Windows.Forms.Padding(3);
            this.tbc_p_needs.Size = new System.Drawing.Size(500, 542);
            this.tbc_p_needs.TabIndex = 1;
            this.tbc_p_needs.Text = "Needs";
            this.tbc_p_needs.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_min_gpu_tflops_sp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_min_gpu_tflops_dp, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_min_ram, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_min_vram, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txt_min_cpu_gflops, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label20, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txt_ram_per_core, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(488, 501);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Miminum CPU GFLOPS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mimimum GPU TFLOPS (SP)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mimimum GPU TFLOPS (DP)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Minimum Primary Memory (GB)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Mimimum GPU Memory (GB)";
            // 
            // txt_min_gpu_tflops_sp
            // 
            this.txt_min_gpu_tflops_sp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_min_gpu_tflops_sp.Location = new System.Drawing.Point(267, 35);
            this.txt_min_gpu_tflops_sp.Name = "txt_min_gpu_tflops_sp";
            this.txt_min_gpu_tflops_sp.Size = new System.Drawing.Size(218, 26);
            this.txt_min_gpu_tflops_sp.TabIndex = 6;
            this.txt_min_gpu_tflops_sp.Text = "400";
            // 
            // txt_min_gpu_tflops_dp
            // 
            this.txt_min_gpu_tflops_dp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_min_gpu_tflops_dp.Location = new System.Drawing.Point(267, 67);
            this.txt_min_gpu_tflops_dp.Name = "txt_min_gpu_tflops_dp";
            this.txt_min_gpu_tflops_dp.Size = new System.Drawing.Size(218, 26);
            this.txt_min_gpu_tflops_dp.TabIndex = 7;
            this.txt_min_gpu_tflops_dp.Text = "150";
            // 
            // txt_min_ram
            // 
            this.txt_min_ram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_min_ram.Location = new System.Drawing.Point(267, 99);
            this.txt_min_ram.Name = "txt_min_ram";
            this.txt_min_ram.Size = new System.Drawing.Size(218, 26);
            this.txt_min_ram.TabIndex = 8;
            this.txt_min_ram.Text = "512";
            // 
            // txt_min_vram
            // 
            this.txt_min_vram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_min_vram.Location = new System.Drawing.Point(267, 131);
            this.txt_min_vram.Name = "txt_min_vram";
            this.txt_min_vram.Size = new System.Drawing.Size(218, 26);
            this.txt_min_vram.TabIndex = 9;
            this.txt_min_vram.Text = "512";
            // 
            // txt_min_cpu_gflops
            // 
            this.txt_min_cpu_gflops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_min_cpu_gflops.Location = new System.Drawing.Point(267, 3);
            this.txt_min_cpu_gflops.Name = "txt_min_cpu_gflops";
            this.txt_min_cpu_gflops.Size = new System.Drawing.Size(218, 26);
            this.txt_min_cpu_gflops.TabIndex = 5;
            this.txt_min_cpu_gflops.Text = "700000";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 160);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(256, 40);
            this.label20.TabIndex = 10;
            this.label20.Text = "Minimum RAM per Processor Core (GB)";
            // 
            // txt_ram_per_core
            // 
            this.txt_ram_per_core.Location = new System.Drawing.Point(267, 163);
            this.txt_ram_per_core.Name = "txt_ram_per_core";
            this.txt_ram_per_core.Size = new System.Drawing.Size(218, 26);
            this.txt_ram_per_core.TabIndex = 11;
            this.txt_ram_per_core.Text = "4";
            // 
            // tbc_p_extrainfo
            // 
            this.tbc_p_extrainfo.Controls.Add(this.tableLayoutPanel2);
            this.tbc_p_extrainfo.Location = new System.Drawing.Point(4, 29);
            this.tbc_p_extrainfo.Name = "tbc_p_extrainfo";
            this.tbc_p_extrainfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbc_p_extrainfo.Size = new System.Drawing.Size(500, 542);
            this.tbc_p_extrainfo.TabIndex = 2;
            this.tbc_p_extrainfo.Text = "Constraints";
            this.tbc_p_extrainfo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label10, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label13, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.txt_total_budget, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txt_monthly_power_budget, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txt_max_power_delivery, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.txt_max_rack_power, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.txt_max_racks, 1, 7);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(488, 354);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Total Budget (USD)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(217, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Monthly Power Budget (USD)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(222, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Max Total Power Draw (Watts)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(251, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Max Power Draw per Rack (Watts)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 188);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(216, 20);
            this.label14.TabIndex = 11;
            this.label14.Text = "Maximum Number # of Racks";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(260, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Power Constraints";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(225, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Budget Constraints";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(260, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(225, 20);
            this.label13.TabIndex = 6;
            this.label13.Text = "Space Constraint";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_total_budget
            // 
            this.txt_total_budget.Location = new System.Drawing.Point(260, 23);
            this.txt_total_budget.Name = "txt_total_budget";
            this.txt_total_budget.Size = new System.Drawing.Size(225, 26);
            this.txt_total_budget.TabIndex = 12;
            this.txt_total_budget.Text = "500000";
            // 
            // txt_monthly_power_budget
            // 
            this.txt_monthly_power_budget.Location = new System.Drawing.Point(260, 55);
            this.txt_monthly_power_budget.Name = "txt_monthly_power_budget";
            this.txt_monthly_power_budget.Size = new System.Drawing.Size(225, 26);
            this.txt_monthly_power_budget.TabIndex = 13;
            this.txt_monthly_power_budget.Text = "4000";
            // 
            // txt_max_power_delivery
            // 
            this.txt_max_power_delivery.Location = new System.Drawing.Point(260, 107);
            this.txt_max_power_delivery.Name = "txt_max_power_delivery";
            this.txt_max_power_delivery.Size = new System.Drawing.Size(225, 26);
            this.txt_max_power_delivery.TabIndex = 14;
            this.txt_max_power_delivery.Text = "70000";
            // 
            // txt_max_rack_power
            // 
            this.txt_max_rack_power.Location = new System.Drawing.Point(260, 139);
            this.txt_max_rack_power.Name = "txt_max_rack_power";
            this.txt_max_rack_power.Size = new System.Drawing.Size(225, 26);
            this.txt_max_rack_power.TabIndex = 15;
            this.txt_max_rack_power.Text = "10000";
            // 
            // txt_max_racks
            // 
            this.txt_max_racks.Location = new System.Drawing.Point(260, 191);
            this.txt_max_racks.Name = "txt_max_racks";
            this.txt_max_racks.Size = new System.Drawing.Size(225, 26);
            this.txt_max_racks.TabIndex = 16;
            this.txt_max_racks.Text = "5";
            // 
            // tbc_p_recommendation
            // 
            this.tbc_p_recommendation.Controls.Add(this.btn_reset);
            this.tbc_p_recommendation.Controls.Add(this.btn_start);
            this.tbc_p_recommendation.Controls.Add(this.tableLayoutPanel3);
            this.tbc_p_recommendation.Location = new System.Drawing.Point(4, 29);
            this.tbc_p_recommendation.Name = "tbc_p_recommendation";
            this.tbc_p_recommendation.Padding = new System.Windows.Forms.Padding(3);
            this.tbc_p_recommendation.Size = new System.Drawing.Size(500, 542);
            this.tbc_p_recommendation.TabIndex = 3;
            this.tbc_p_recommendation.Text = "Extra Information";
            this.tbc_p_recommendation.UseVisualStyleBackColor = true;
            // 
            // btn_reset
            // 
            this.btn_reset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reset.Location = new System.Drawing.Point(6, 454);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(489, 38);
            this.btn_reset.TabIndex = 2;
            this.btn_reset.Text = "< CLEAR >";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click_1);
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.Location = new System.Drawing.Point(5, 498);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(489, 38);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "< START >";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label18, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label19, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.txt_construction_cost, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmb_average_load_percent, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.txt_daily_load_hours, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txt_weekly_load_days, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txt_electricity_cost, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 6);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 10;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(488, 397);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(246, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Construction Cost (% of unit cost)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(204, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "Daily Load Time (hours/day)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(228, 20);
            this.label17.TabIndex = 2;
            this.label17.Text = "Weekly Load Days (days/week)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(207, 20);
            this.label18.TabIndex = 3;
            this.label18.Text = "Expected Average Load (%)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 130);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(197, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "Electricity Cost (USD/kwH)";
            // 
            // txt_construction_cost
            // 
            this.txt_construction_cost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_construction_cost.Location = new System.Drawing.Point(255, 3);
            this.txt_construction_cost.Name = "txt_construction_cost";
            this.txt_construction_cost.Size = new System.Drawing.Size(268, 26);
            this.txt_construction_cost.TabIndex = 9;
            this.txt_construction_cost.Text = "10";
            // 
            // cmb_average_load_percent
            // 
            this.cmb_average_load_percent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_average_load_percent.FormattingEnabled = true;
            this.cmb_average_load_percent.Items.AddRange(new object[] {
            "100",
            "90",
            "80",
            "70",
            "60",
            "50"});
            this.cmb_average_load_percent.Location = new System.Drawing.Point(255, 99);
            this.cmb_average_load_percent.Name = "cmb_average_load_percent";
            this.cmb_average_load_percent.Size = new System.Drawing.Size(268, 28);
            this.cmb_average_load_percent.TabIndex = 10;
            this.cmb_average_load_percent.Text = "70";
            // 
            // txt_daily_load_hours
            // 
            this.txt_daily_load_hours.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_daily_load_hours.Location = new System.Drawing.Point(255, 35);
            this.txt_daily_load_hours.Name = "txt_daily_load_hours";
            this.txt_daily_load_hours.Size = new System.Drawing.Size(268, 26);
            this.txt_daily_load_hours.TabIndex = 11;
            this.txt_daily_load_hours.Text = "18";
            // 
            // txt_weekly_load_days
            // 
            this.txt_weekly_load_days.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_weekly_load_days.Location = new System.Drawing.Point(255, 67);
            this.txt_weekly_load_days.Name = "txt_weekly_load_days";
            this.txt_weekly_load_days.Size = new System.Drawing.Size(268, 26);
            this.txt_weekly_load_days.TabIndex = 12;
            this.txt_weekly_load_days.Text = "5";
            // 
            // txt_electricity_cost
            // 
            this.txt_electricity_cost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_electricity_cost.Location = new System.Drawing.Point(255, 133);
            this.txt_electricity_cost.Name = "txt_electricity_cost";
            this.txt_electricity_cost.Size = new System.Drawing.Size(268, 26);
            this.txt_electricity_cost.TabIndex = 13;
            this.txt_electricity_cost.Text = "0.2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 14;
            // 
            // sampleInputToolStripMenuItem
            // 
            this.sampleInputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noResultToolStripMenuItem,
            this.resultToolStripMenuItem,
            this.lotsOfResultsToolStripMenuItem});
            this.sampleInputToolStripMenuItem.Name = "sampleInputToolStripMenuItem";
            this.sampleInputToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sampleInputToolStripMenuItem.Text = "Sample Input";

            // 
            // noResultToolStripMenuItem
            // 
            this.noResultToolStripMenuItem.Name = "noResultToolStripMenuItem";
            this.noResultToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.noResultToolStripMenuItem.Text = "No Result";
            this.noResultToolStripMenuItem.Click += new System.EventHandler(this.noResultToolStripMenuItem_Click);
            // 
            // resultToolStripMenuItem
            // 
            this.resultToolStripMenuItem.Name = "resultToolStripMenuItem";
            this.resultToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resultToolStripMenuItem.Text = "1 Result";
            this.resultToolStripMenuItem.Click += new System.EventHandler(this.resultToolStripMenuItem_Click);
            // 
            // lotsOfResultsToolStripMenuItem
            // 
            this.lotsOfResultsToolStripMenuItem.Name = "lotsOfResultsToolStripMenuItem";
            this.lotsOfResultsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lotsOfResultsToolStripMenuItem.Text = "Lots of results";
            this.lotsOfResultsToolStripMenuItem.Click += new System.EventHandler(this.lotsOfResultsToolStripMenuItem_Click);
            // 
            // saveOutputToolStripMenuItem
            // 
            this.saveOutputToolStripMenuItem.Name = "saveOutputToolStripMenuItem";
            this.saveOutputToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveOutputToolStripMenuItem.Text = "Save Output";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // frm_CDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1277, 669);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_log_rec);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frm_CDT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cluster Design Tool";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gb_log_rec.ResumeLayout(false);
            this.gb_log_rec.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tbc.ResumeLayout(false);
            this.tbc_p_welcome.ResumeLayout(false);
            this.tbc_p_welcome.PerformLayout();
            this.tbc_p_needs.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tbc_p_extrainfo.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tbc_p_recommendation.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar prg_1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox gb_log_rec;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tbc;
        private System.Windows.Forms.TabPage tbc_p_welcome;
        private System.Windows.Forms.TextBox txt_welcome;
        private System.Windows.Forms.TabPage tbc_p_needs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_min_gpu_tflops_sp;
        private System.Windows.Forms.TextBox txt_min_gpu_tflops_dp;
        private System.Windows.Forms.TextBox txt_min_ram;
        private System.Windows.Forms.TextBox txt_min_vram;
        private System.Windows.Forms.TextBox txt_min_cpu_gflops;
        private System.Windows.Forms.TabPage tbc_p_extrainfo;
        private System.Windows.Forms.TabPage tbc_p_recommendation;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_construction_cost;
        private System.Windows.Forms.ComboBox cmb_average_load_percent;
        private System.Windows.Forms.TextBox txt_daily_load_hours;
        private System.Windows.Forms.TextBox txt_weekly_load_days;
        private System.Windows.Forms.TextBox txt_electricity_cost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_ram_per_core;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_total_budget;
        private System.Windows.Forms.TextBox txt_monthly_power_budget;
        private System.Windows.Forms.TextBox txt_max_power_delivery;
        private System.Windows.Forms.TextBox txt_max_rack_power;
        private System.Windows.Forms.TextBox txt_max_racks;
        private System.Windows.Forms.ToolStripMenuItem saveOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sampleInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lotsOfResultsToolStripMenuItem;



    }
}

