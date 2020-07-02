namespace DownloadDict
  {
  partial class Form1
    {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
      {
      if( disposing && (components != null) )
        {
        components.Dispose();
        }
      base.Dispose( disposing );
      }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
      {
      this.btnFindWrds = new System.Windows.Forms.Button();
      this.chkProxy = new System.Windows.Forms.CheckBox();
      this.lbAddress = new System.Windows.Forms.Label();
      this.txtAdress = new System.Windows.Forms.TextBox();
      this.lbPort = new System.Windows.Forms.Label();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.grp1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.lbMsgs = new System.Windows.Forms.Label();
      this.txtWorkDir = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.SelFolderDlg = new System.Windows.Forms.FolderBrowserDialog();
      this.btnWorkDir = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.cbLangs = new System.Windows.Forms.ComboBox();
      this.btnCancel = new System.Windows.Forms.Button();
      this.boxDatos = new System.Windows.Forms.Panel();
      this.btnContinue = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.lbDwnRate = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.lbDwnSkipsWrds = new System.Windows.Forms.Label();
      this.lbDwnSkipsRngs = new System.Windows.Forms.Label();
      this.lbDwnSkipsLtrs = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.lbFrmErrorsWrds = new System.Windows.Forms.Label();
      this.lbFrmErrorsRngs = new System.Windows.Forms.Label();
      this.lbFrmErrorsLtrs = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.lbDwnErrorsWrds = new System.Windows.Forms.Label();
      this.lbDwnErrorsRngs = new System.Windows.Forms.Label();
      this.lbDwnErrorsLtrs = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.lbDwnOkWrds = new System.Windows.Forms.Label();
      this.lbDwnOkRngs = new System.Windows.Forms.Label();
      this.lbDwnOkLtrs = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.lbPCWords = new System.Windows.Forms.Label();
      this.lbPCRanges = new System.Windows.Forms.Label();
      this.label22 = new System.Windows.Forms.Label();
      this.lbNumWords = new System.Windows.Forms.Label();
      this.label21 = new System.Windows.Forms.Label();
      this.lbPCLetters = new System.Windows.Forms.Label();
      this.label20 = new System.Windows.Forms.Label();
      this.lbNumRanges = new System.Windows.Forms.Label();
      this.lbNumLetras = new System.Windows.Forms.Label();
      this.btnDownWords = new System.Windows.Forms.Button();
      this.grp1.SuspendLayout();
      this.boxDatos.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnFindWrds
      // 
      this.btnFindWrds.Location = new System.Drawing.Point(12, 225);
      this.btnFindWrds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnFindWrds.Name = "btnFindWrds";
      this.btnFindWrds.Size = new System.Drawing.Size(180, 38);
      this.btnFindWrds.TabIndex = 50;
      this.btnFindWrds.Text = "Encontrar Palabras";
      this.btnFindWrds.UseVisualStyleBackColor = true;
      this.btnFindWrds.Click += new System.EventHandler(this.btnFindWrds_Click);
      // 
      // chkProxy
      // 
      this.chkProxy.AutoSize = true;
      this.chkProxy.Checked = true;
      this.chkProxy.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkProxy.Location = new System.Drawing.Point(28, 14);
      this.chkProxy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.chkProxy.Name = "chkProxy";
      this.chkProxy.Size = new System.Drawing.Size(200, 21);
      this.chkProxy.TabIndex = 1;
      this.chkProxy.Text = "La conección usa un Proxy";
      this.chkProxy.UseVisualStyleBackColor = true;
      // 
      // lbAddress
      // 
      this.lbAddress.AutoSize = true;
      this.lbAddress.Location = new System.Drawing.Point(37, 27);
      this.lbAddress.Name = "lbAddress";
      this.lbAddress.Size = new System.Drawing.Size(71, 17);
      this.lbAddress.TabIndex = 2;
      this.lbAddress.Text = "Dirección:";
      // 
      // txtAdress
      // 
      this.txtAdress.Location = new System.Drawing.Point(120, 25);
      this.txtAdress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.txtAdress.Name = "txtAdress";
      this.txtAdress.Size = new System.Drawing.Size(112, 22);
      this.txtAdress.TabIndex = 3;
      this.txtAdress.Text = "200.55.187.234";
      // 
      // lbPort
      // 
      this.lbPort.AutoSize = true;
      this.lbPort.Location = new System.Drawing.Point(252, 27);
      this.lbPort.Name = "lbPort";
      this.lbPort.Size = new System.Drawing.Size(54, 17);
      this.lbPort.TabIndex = 2;
      this.lbPort.Text = "Puerto:";
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(308, 25);
      this.txtPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(60, 22);
      this.txtPort.TabIndex = 3;
      this.txtPort.Text = "8080";
      // 
      // grp1
      // 
      this.grp1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.grp1.Controls.Add(this.txtPort);
      this.grp1.Controls.Add(this.lbAddress);
      this.grp1.Controls.Add(this.lbPort);
      this.grp1.Controls.Add(this.txtAdress);
      this.grp1.Location = new System.Drawing.Point(12, 17);
      this.grp1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.grp1.Name = "grp1";
      this.grp1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.grp1.Size = new System.Drawing.Size(709, 58);
      this.grp1.TabIndex = 4;
      this.grp1.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 274);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "Mensajes:";
      // 
      // lbMsgs
      // 
      this.lbMsgs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbMsgs.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.lbMsgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbMsgs.Location = new System.Drawing.Point(12, 294);
      this.lbMsgs.Name = "lbMsgs";
      this.lbMsgs.Size = new System.Drawing.Size(709, 73);
      this.lbMsgs.TabIndex = 2;
      // 
      // txtWorkDir
      // 
      this.txtWorkDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtWorkDir.Location = new System.Drawing.Point(12, 112);
      this.txtWorkDir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.txtWorkDir.Name = "txtWorkDir";
      this.txtWorkDir.Size = new System.Drawing.Size(669, 22);
      this.txtWorkDir.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 92);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(273, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "Directorio donde se guarda la información";
      // 
      // btnWorkDir
      // 
      this.btnWorkDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnWorkDir.Location = new System.Drawing.Point(688, 110);
      this.btnWorkDir.Margin = new System.Windows.Forms.Padding(4);
      this.btnWorkDir.Name = "btnWorkDir";
      this.btnWorkDir.Size = new System.Drawing.Size(33, 28);
      this.btnWorkDir.TabIndex = 7;
      this.btnWorkDir.Text = "...";
      this.btnWorkDir.UseVisualStyleBackColor = true;
      this.btnWorkDir.Click += new System.EventHandler(this.btnWorkDir_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(9, 164);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(174, 17);
      this.label3.TabIndex = 2;
      this.label3.Text = "Idioma de los diccionarios:";
      // 
      // cbLangs
      // 
      this.cbLangs.FormattingEnabled = true;
      this.cbLangs.Items.AddRange(new object[] {
            "Español -> Inglés",
            "Inglés    -> Español",
            "Italiano  -> Inglés",
            "Inglés    -> Italiano",
            "Francés  -> Inglés",
            "Inglés     -> Francés"});
      this.cbLangs.Location = new System.Drawing.Point(188, 161);
      this.cbLangs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.cbLangs.Name = "cbLangs";
      this.cbLangs.Size = new System.Drawing.Size(153, 24);
      this.cbLangs.TabIndex = 8;
      this.cbLangs.SelectedIndexChanged += new System.EventHandler(this.cbLangs_SelectedIndexChanged);
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnCancel.Location = new System.Drawing.Point(587, 196);
      this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(107, 38);
      this.btnCancel.TabIndex = 0;
      this.btnCancel.Text = "Cancelar";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // boxDatos
      // 
      this.boxDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.boxDatos.Controls.Add(this.btnContinue);
      this.boxDatos.Controls.Add(this.btnClose);
      this.boxDatos.Controls.Add(this.btnCancel);
      this.boxDatos.Controls.Add(this.lbDwnRate);
      this.boxDatos.Controls.Add(this.label9);
      this.boxDatos.Controls.Add(this.lbDwnSkipsWrds);
      this.boxDatos.Controls.Add(this.lbDwnSkipsRngs);
      this.boxDatos.Controls.Add(this.lbDwnSkipsLtrs);
      this.boxDatos.Controls.Add(this.label8);
      this.boxDatos.Controls.Add(this.lbFrmErrorsWrds);
      this.boxDatos.Controls.Add(this.lbFrmErrorsRngs);
      this.boxDatos.Controls.Add(this.lbFrmErrorsLtrs);
      this.boxDatos.Controls.Add(this.label7);
      this.boxDatos.Controls.Add(this.lbDwnErrorsWrds);
      this.boxDatos.Controls.Add(this.lbDwnErrorsRngs);
      this.boxDatos.Controls.Add(this.lbDwnErrorsLtrs);
      this.boxDatos.Controls.Add(this.label6);
      this.boxDatos.Controls.Add(this.lbDwnOkWrds);
      this.boxDatos.Controls.Add(this.lbDwnOkRngs);
      this.boxDatos.Controls.Add(this.lbDwnOkLtrs);
      this.boxDatos.Controls.Add(this.label5);
      this.boxDatos.Controls.Add(this.label4);
      this.boxDatos.Controls.Add(this.lbPCWords);
      this.boxDatos.Controls.Add(this.lbPCRanges);
      this.boxDatos.Controls.Add(this.label22);
      this.boxDatos.Controls.Add(this.lbNumWords);
      this.boxDatos.Controls.Add(this.label21);
      this.boxDatos.Controls.Add(this.lbPCLetters);
      this.boxDatos.Controls.Add(this.label20);
      this.boxDatos.Controls.Add(this.lbNumRanges);
      this.boxDatos.Controls.Add(this.lbNumLetras);
      this.boxDatos.Location = new System.Drawing.Point(12, 14);
      this.boxDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.boxDatos.Name = "boxDatos";
      this.boxDatos.Size = new System.Drawing.Size(709, 258);
      this.boxDatos.TabIndex = 9;
      this.boxDatos.Visible = false;
      // 
      // btnContinue
      // 
      this.btnContinue.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnContinue.Location = new System.Drawing.Point(587, 106);
      this.btnContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnContinue.Name = "btnContinue";
      this.btnContinue.Size = new System.Drawing.Size(107, 38);
      this.btnContinue.TabIndex = 0;
      this.btnContinue.Text = "Retornar";
      this.btnContinue.UseVisualStyleBackColor = true;
      this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnClose.Location = new System.Drawing.Point(587, 150);
      this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(107, 38);
      this.btnClose.TabIndex = 0;
      this.btnClose.Text = "Cerrar";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // lbDwnRate
      // 
      this.lbDwnRate.AutoSize = true;
      this.lbDwnRate.Location = new System.Drawing.Point(257, 231);
      this.lbDwnRate.Name = "lbDwnRate";
      this.lbDwnRate.Size = new System.Drawing.Size(108, 17);
      this.lbDwnRate.TabIndex = 2;
      this.lbDwnRate.Text = "                         ";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(77, 233);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(157, 17);
      this.label9.TabIndex = 2;
      this.label9.Text = "Velocidad de descarga:";
      // 
      // lbDwnSkipsWrds
      // 
      this.lbDwnSkipsWrds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbDwnSkipsWrds.Location = new System.Drawing.Point(412, 172);
      this.lbDwnSkipsWrds.Name = "lbDwnSkipsWrds";
      this.lbDwnSkipsWrds.Size = new System.Drawing.Size(71, 22);
      this.lbDwnSkipsWrds.TabIndex = 2;
      this.lbDwnSkipsWrds.Text = "                         ";
      // 
      // lbDwnSkipsRngs
      // 
      this.lbDwnSkipsRngs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbDwnSkipsRngs.Location = new System.Drawing.Point(335, 172);
      this.lbDwnSkipsRngs.Name = "lbDwnSkipsRngs";
      this.lbDwnSkipsRngs.Size = new System.Drawing.Size(71, 22);
      this.lbDwnSkipsRngs.TabIndex = 2;
      this.lbDwnSkipsRngs.Text = "                         ";
      // 
      // lbDwnSkipsLtrs
      // 
      this.lbDwnSkipsLtrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbDwnSkipsLtrs.Location = new System.Drawing.Point(257, 172);
      this.lbDwnSkipsLtrs.Name = "lbDwnSkipsLtrs";
      this.lbDwnSkipsLtrs.Size = new System.Drawing.Size(71, 22);
      this.lbDwnSkipsLtrs.TabIndex = 2;
      this.lbDwnSkipsLtrs.Text = "                         ";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(109, 175);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(149, 17);
      this.label8.TabIndex = 2;
      this.label8.Text = "Descargas Anteriores:";
      // 
      // lbFrmErrorsWrds
      // 
      this.lbFrmErrorsWrds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbFrmErrorsWrds.Location = new System.Drawing.Point(412, 144);
      this.lbFrmErrorsWrds.Name = "lbFrmErrorsWrds";
      this.lbFrmErrorsWrds.Size = new System.Drawing.Size(71, 22);
      this.lbFrmErrorsWrds.TabIndex = 2;
      this.lbFrmErrorsWrds.Text = "                         ";
      // 
      // lbFrmErrorsRngs
      // 
      this.lbFrmErrorsRngs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbFrmErrorsRngs.Location = new System.Drawing.Point(335, 144);
      this.lbFrmErrorsRngs.Name = "lbFrmErrorsRngs";
      this.lbFrmErrorsRngs.Size = new System.Drawing.Size(71, 22);
      this.lbFrmErrorsRngs.TabIndex = 2;
      this.lbFrmErrorsRngs.Text = "                         ";
      // 
      // lbFrmErrorsLtrs
      // 
      this.lbFrmErrorsLtrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbFrmErrorsLtrs.Location = new System.Drawing.Point(257, 144);
      this.lbFrmErrorsLtrs.Name = "lbFrmErrorsLtrs";
      this.lbFrmErrorsLtrs.Size = new System.Drawing.Size(71, 22);
      this.lbFrmErrorsLtrs.TabIndex = 2;
      this.lbFrmErrorsLtrs.Text = "                         ";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(127, 146);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(131, 17);
      this.label7.TabIndex = 2;
      this.label7.Text = "Errores de formato:";
      // 
      // lbDwnErrorsWrds
      // 
      this.lbDwnErrorsWrds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbDwnErrorsWrds.Location = new System.Drawing.Point(412, 116);
      this.lbDwnErrorsWrds.Name = "lbDwnErrorsWrds";
      this.lbDwnErrorsWrds.Size = new System.Drawing.Size(71, 22);
      this.lbDwnErrorsWrds.TabIndex = 2;
      this.lbDwnErrorsWrds.Text = "                         ";
      // 
      // lbDwnErrorsRngs
      // 
      this.lbDwnErrorsRngs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbDwnErrorsRngs.Location = new System.Drawing.Point(335, 116);
      this.lbDwnErrorsRngs.Name = "lbDwnErrorsRngs";
      this.lbDwnErrorsRngs.Size = new System.Drawing.Size(71, 22);
      this.lbDwnErrorsRngs.TabIndex = 2;
      this.lbDwnErrorsRngs.Text = "                         ";
      // 
      // lbDwnErrorsLtrs
      // 
      this.lbDwnErrorsLtrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbDwnErrorsLtrs.Location = new System.Drawing.Point(257, 116);
      this.lbDwnErrorsLtrs.Name = "lbDwnErrorsLtrs";
      this.lbDwnErrorsLtrs.Size = new System.Drawing.Size(71, 22);
      this.lbDwnErrorsLtrs.TabIndex = 2;
      this.lbDwnErrorsLtrs.Text = "                         ";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(126, 118);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(132, 17);
      this.label6.TabIndex = 2;
      this.label6.Text = "Descargas Fallidas:";
      // 
      // lbDwnOkWrds
      // 
      this.lbDwnOkWrds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbDwnOkWrds.Location = new System.Drawing.Point(412, 89);
      this.lbDwnOkWrds.Name = "lbDwnOkWrds";
      this.lbDwnOkWrds.Size = new System.Drawing.Size(71, 22);
      this.lbDwnOkWrds.TabIndex = 2;
      // 
      // lbDwnOkRngs
      // 
      this.lbDwnOkRngs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbDwnOkRngs.Location = new System.Drawing.Point(335, 89);
      this.lbDwnOkRngs.Name = "lbDwnOkRngs";
      this.lbDwnOkRngs.Size = new System.Drawing.Size(71, 22);
      this.lbDwnOkRngs.TabIndex = 2;
      // 
      // lbDwnOkLtrs
      // 
      this.lbDwnOkLtrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lbDwnOkLtrs.Location = new System.Drawing.Point(257, 89);
      this.lbDwnOkLtrs.Name = "lbDwnOkLtrs";
      this.lbDwnOkLtrs.Size = new System.Drawing.Size(71, 22);
      this.lbDwnOkLtrs.TabIndex = 2;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(108, 91);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(150, 17);
      this.label5.TabIndex = 2;
      this.label5.Text = "Descargas Completas:";
      // 
      // label4
      // 
      this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(233, 2);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(243, 31);
      this.label4.TabIndex = 2;
      this.label4.Text = "TRABAJANDO ...";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lbPCWords
      // 
      this.lbPCWords.Location = new System.Drawing.Point(412, 196);
      this.lbPCWords.Name = "lbPCWords";
      this.lbPCWords.Size = new System.Drawing.Size(72, 17);
      this.lbPCWords.TabIndex = 2;
      this.lbPCWords.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // lbPCRanges
      // 
      this.lbPCRanges.Location = new System.Drawing.Point(335, 196);
      this.lbPCRanges.Name = "lbPCRanges";
      this.lbPCRanges.Size = new System.Drawing.Size(72, 17);
      this.lbPCRanges.TabIndex = 2;
      this.lbPCRanges.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label22
      // 
      this.label22.AutoSize = true;
      this.label22.Location = new System.Drawing.Point(412, 53);
      this.label22.Name = "label22";
      this.label22.Size = new System.Drawing.Size(64, 17);
      this.label22.TabIndex = 2;
      this.label22.Text = "Palabras";
      this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // lbNumWords
      // 
      this.lbNumWords.Location = new System.Drawing.Point(412, 69);
      this.lbNumWords.Name = "lbNumWords";
      this.lbNumWords.Size = new System.Drawing.Size(72, 17);
      this.lbNumWords.TabIndex = 2;
      this.lbNumWords.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label21
      // 
      this.label21.Location = new System.Drawing.Point(335, 53);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(72, 17);
      this.label21.TabIndex = 2;
      this.label21.Text = "Rangos";
      this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // lbPCLetters
      // 
      this.lbPCLetters.Location = new System.Drawing.Point(257, 196);
      this.lbPCLetters.Name = "lbPCLetters";
      this.lbPCLetters.Size = new System.Drawing.Size(72, 17);
      this.lbPCLetters.TabIndex = 2;
      this.lbPCLetters.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label20
      // 
      this.label20.Location = new System.Drawing.Point(257, 53);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(72, 17);
      this.label20.TabIndex = 2;
      this.label20.Text = "Letras";
      this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // lbNumRanges
      // 
      this.lbNumRanges.Location = new System.Drawing.Point(335, 69);
      this.lbNumRanges.Name = "lbNumRanges";
      this.lbNumRanges.Size = new System.Drawing.Size(72, 17);
      this.lbNumRanges.TabIndex = 2;
      this.lbNumRanges.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // lbNumLetras
      // 
      this.lbNumLetras.Location = new System.Drawing.Point(257, 69);
      this.lbNumLetras.Name = "lbNumLetras";
      this.lbNumLetras.Size = new System.Drawing.Size(72, 17);
      this.lbNumLetras.TabIndex = 2;
      this.lbNumLetras.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // btnDownWords
      // 
      this.btnDownWords.Location = new System.Drawing.Point(268, 225);
      this.btnDownWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.btnDownWords.Name = "btnDownWords";
      this.btnDownWords.Size = new System.Drawing.Size(180, 38);
      this.btnDownWords.TabIndex = 100;
      this.btnDownWords.Text = "Descargar Palabras";
      this.btnDownWords.UseVisualStyleBackColor = true;
      this.btnDownWords.Click += new System.EventHandler(this.btnDownWords_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(733, 375);
      this.Controls.Add(this.boxDatos);
      this.Controls.Add(this.cbLangs);
      this.Controls.Add(this.btnWorkDir);
      this.Controls.Add(this.chkProxy);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnDownWords);
      this.Controls.Add(this.btnFindWrds);
      this.Controls.Add(this.lbMsgs);
      this.Controls.Add(this.txtWorkDir);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.grp1);
      this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Datos de los diccionarios de Collins";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.grp1.ResumeLayout(false);
      this.grp1.PerformLayout();
      this.boxDatos.ResumeLayout(false);
      this.boxDatos.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

      }

    #endregion
    private System.Windows.Forms.Button btnFindWrds;
    private System.Windows.Forms.CheckBox chkProxy;
    private System.Windows.Forms.Label lbAddress;
    private System.Windows.Forms.TextBox txtAdress;
    private System.Windows.Forms.Label lbPort;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.GroupBox grp1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lbMsgs;
    private System.Windows.Forms.TextBox txtWorkDir;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.FolderBrowserDialog SelFolderDlg;
    private System.Windows.Forms.Button btnWorkDir;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbLangs;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Panel boxDatos;
    private System.Windows.Forms.Label lbDwnRate;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnContinue;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Label lbDwnSkipsRngs;
    private System.Windows.Forms.Label lbDwnSkipsLtrs;
    private System.Windows.Forms.Label lbFrmErrorsRngs;
    private System.Windows.Forms.Label lbFrmErrorsLtrs;
    private System.Windows.Forms.Label lbDwnErrorsRngs;
    private System.Windows.Forms.Label lbDwnErrorsLtrs;
    private System.Windows.Forms.Label lbDwnOkRngs;
    private System.Windows.Forms.Label lbDwnOkLtrs;
    private System.Windows.Forms.Label lbDwnSkipsWrds;
    private System.Windows.Forms.Label lbFrmErrorsWrds;
    private System.Windows.Forms.Label lbDwnErrorsWrds;
    private System.Windows.Forms.Label lbDwnOkWrds;
    private System.Windows.Forms.Label lbPCWords;
    private System.Windows.Forms.Label lbPCRanges;
    private System.Windows.Forms.Label label22;
    private System.Windows.Forms.Label lbNumWords;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.Label lbPCLetters;
    private System.Windows.Forms.Label label20;
    private System.Windows.Forms.Label lbNumRanges;
    private System.Windows.Forms.Label lbNumLetras;
    private System.Windows.Forms.Button btnDownWords;
    }
  }

